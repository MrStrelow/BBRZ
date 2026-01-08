using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.DTOs;
using FruehstuecksBestellungMVC.Exceptions;
using FruehstuecksBestellungMVC.Models;
using FruehstuecksBestellungMVC.Models.Enums;
using FruehstuecksBestellungMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FruehstuecksBestellungMVC.Services;

public class CustomerService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CustomerService> _logger;

    public CustomerService(ApplicationDbContext context, ILogger<CustomerService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task CreateOrderAsync(OrderDto orderDto)
    {
        // 1. Logger hinzufügen
        _logger.LogInformation("Starte Bestellung für Kunde ID {CustomerId}, Typ: {Type}", orderDto.CustomerId, orderDto.Type);

        var customer = await _context.Customers.FindAsync(orderDto.CustomerId);

        if (customer is null)
        {
            // 2. Logging & Custom Exception
            _logger.LogWarning("Bestellung fehlgeschlagen: Kunde ID {Id} nicht gefunden.", orderDto.CustomerId);
            throw new FruehstueckBusinessException("Der angegebene Kunde konnte nicht gefunden werden.");
        }

        // Preise berechnen
        var menus = await _context.Menus.Where(m => orderDto.SelectedMenuIds.Contains(m.Id)).ToListAsync();
        var dishes = await _context.Dishes.Where(d => orderDto.SelectedDishIds.Contains(d.Id)).ToListAsync();
        decimal totalAmount = menus.Sum(m => m.Price) + dishes.Sum(d => d.Price);

        // Basis-Objekte
        var order = new Order
        {
            OrderTime = DateTime.UtcNow,
            Menus = menus,
            Dishes = dishes
        };

        var bill = new Bill
        {
            TotalAmount = totalAmount,
            BillDate = DateTime.UtcNow
        };

        // --- Logik-Weiche je nach OrderType ---

        if (orderDto.Type == OrderType.TakeIn)
        {
            var simulation = new Random().NextDouble() < 0.5;

            if (orderDto.TableId == 13 || simulation)
            {
                throw new FruehstueckBusinessException("Tisch 13 ist wegen Aberglaube gesperrt.");
            }

            // Die Order wird dem Visit hinzugefügt.
            if (!orderDto.TableId.HasValue)
            {
                _logger.LogWarning("Versuch einer Restaurant-Bestellung ohne Tisch.");
                throw new FruehstueckBusinessException("Für Bestellungen im Restaurant ist ein Tisch erforderlich.");
            }

            // Visit Logik: Visit hat 1 Bill und N Orders.
            var table = await _context.Tables.FindAsync(orderDto.TableId);

            var visit = new Visit { EntryTime = DateTime.UtcNow, Table = table, Customers = { customer } };

            // Verknüpfungen setzen
            visit.Bill = bill;           // Visit -> 1 Bill
            visit.Orders.Add(order);     // Visit -> N Orders

            _context.Visits.Add(visit);
        }
        else if (orderDto.Type == OrderType.Delivery)
        {
            // Delivery Logik: Delivery hat 1 Bill und 1 Order.
            var delivery = new Delivery
            {
                Customer = customer,
                DeliveryAddress = orderDto.DeliveryAddress!,
                DeliveryEmail = orderDto.DeliveryEmail,
                DeliveryPhone = orderDto.DeliveryPhone,
                ExpectedDeliveryDate = orderDto.ExpectedDeliveryDate,
                CreatedDate = DateTime.UtcNow
            };

            // Verknüpfungen setzen
            delivery.Bill = bill;    // Delivery -> 1 Bill
            delivery.Order = order;  // Delivery -> 1 Order

            _context.Deliveries.Add(delivery);
        }
        else if (orderDto.Type == OrderType.TakeAway)
        {
            // TakeAway Logik: TakeAway hat 1 Bill und 1 Order.
            var takeAway = new TakeAway
            {
                Customer = customer,
                PickupTime = DateTime.UtcNow.AddMinutes(30) // Standardwert
            };

            // Verknüpfungen setzen
            takeAway.Bill = bill;   // TakeAway -> 1 Bill
            takeAway.Orders = order; // TakeAway -> 1 Order (Property heißt im Model 'Orders', ist aber 'Order?')

            _context.TakeAways.Add(takeAway);
        }

        // Hinweis: EF Core fügt referenzierte Objekte (Order, Bill) automatisch hinzu,
        // wenn das Parent (Visit/Delivery/TakeAway) hinzugefügt wird.
        await _context.SaveChangesAsync();
        _logger.LogInformation("Bestellung erfolgreich gespeichert. Rechnungsbetrag: {Amount}", totalAmount);
    }

    // Neue Methode für die Management View
    public async Task UpdateDeliveryAsync(DeliveryManagementViewModel vm)
    {
        _logger.LogInformation("Aktualisiere Lieferung ID {DeliveryId}", vm.DeliveryId);

        var delivery = await _context.Deliveries
            .Include(d => d.Order)
            .FirstOrDefaultAsync(d => d.Id == vm.DeliveryId);

        if (delivery is null)
        {
            _logger.LogWarning("Lieferung ID {DeliveryId} für Update nicht gefunden.", vm.DeliveryId);
            throw new FruehstueckBusinessException("Die gesuchte Lieferung konnte nicht gefunden werden.");
        }

        if (vm.IsCanceled)
        {
            // Storno nur möglich, wenn noch kein Lieferdatum eingetragen war
            // Guard
            if (delivery.ActualDeliveryDate != null)
            { 
                _logger.LogWarning("Versuch, eine bereits gelieferte Bestellung (ID {Id}) zu stornieren.", delivery.Id);
                throw new FruehstueckBusinessException("Bereits ausgelieferte Bestellungen können nicht mehr storniert werden.");
            }

            delivery.IsCanceled = true;
            _logger.LogInformation("Lieferung ID {Id} wurde erfolgreich storniert.", delivery.Id);
        }
        else
        {
            // Daten aktualisieren
            delivery.DeliveryComment = vm.DeliveryComment;
            delivery.ActualDeliveryDate = vm.ActualDeliveryDate; // Kann null sein, oder gesetzt
            delivery.ExpectedDeliveryDate = vm.ExpectedDeliveryDate;

            // Bild speichern
            if (vm.DeliveryImage != null)
            {
                try
                {
                    // Simulation eines Fehlers
                    if (new Random().NextDouble() < 0.5)
                    {
                        throw new Exception("Simulation einer vollen Disk.");
                    }

                    var folderName = "delivery_proofs";
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Dateiname erstellen, überschreibt existierendes Bild der selben Order
                    var fileName = $"proof_delivery_{delivery.Id}{Path.GetExtension(vm.DeliveryImage.FileName)}";
                    var filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await vm.DeliveryImage.CopyToAsync(stream);
                    }

                    delivery.DeliveryImagePath = $"/{folderName}/{fileName}";
                }
                catch (Exception ex)
                {
                    // Technische Fehler (z.B. Festplatte voll, Rechte fehlen) loggen wir als Error
                    _logger.LogError(ex, "Fehler beim Upload des Lieferbildes für ID {Id}", delivery.Id);
                    // Wir werfen den Fehler weiter, damit die Middleware ihn als 500er (technischen Fehler) behandelt
                    throw;
                }
            }
        }

        await _context.SaveChangesAsync();
        _logger.LogInformation("Update für Lieferung ID {Id} erfolgreich abgeschlossen.", delivery.Id);
    }
}