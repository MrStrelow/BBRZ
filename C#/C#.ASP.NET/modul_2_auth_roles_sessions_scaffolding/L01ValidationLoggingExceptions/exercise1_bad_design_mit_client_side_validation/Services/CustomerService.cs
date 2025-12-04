using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.Models;
using FruehstuecksBestellungMVC.DTOs;
using FruehstuecksBestellungMVC.Models.Enums;
using FruehstuecksBestellungMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FruehstuecksBestellungMVC.Services;

public class CustomerService
{
    private readonly ApplicationDbContext _context;

    public CustomerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateOrderAsync(OrderDto orderDto)
    {
        var customer = await _context.Customers.FindAsync(orderDto.CustomerId);
        if (customer is null) throw new InvalidOperationException("Kunde nicht gefunden.");

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
            // Visit Logik: Visit hat 1 Bill und N Orders.
            // Die Order wird dem Visit hinzugefügt.
            if (!orderDto.TableId.HasValue) throw new InvalidOperationException("Tisch fehlt.");
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
    }

    // Neue Methode für die Management View
    public async Task UpdateDeliveryAsync(DeliveryManagementViewModel vm)
    {
        var delivery = await _context.Deliveries
            .Include(d => d.Order)
            .FirstOrDefaultAsync(d => d.Id == vm.DeliveryId);

        if (delivery == null) throw new ArgumentException("Lieferung nicht gefunden");

        if (vm.IsCanceled)
        {
            // Storno nur möglich, wenn noch kein Lieferdatum eingetragen war
            if (delivery.ActualDeliveryDate == null)
            {
                delivery.IsCanceled = true;
            }
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
                var folderName = "delivery_proofs";
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                // Dateiname erstellen, überschreibt existierendes Bild der selben Order
                var fileName = $"proof_delivery_{delivery.Id}{Path.GetExtension(vm.DeliveryImage.FileName)}";
                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await vm.DeliveryImage.CopyToAsync(stream);
                }

                delivery.DeliveryImagePath = $"/{folderName}/{fileName}";
            }
        }

        await _context.SaveChangesAsync();
    }
}