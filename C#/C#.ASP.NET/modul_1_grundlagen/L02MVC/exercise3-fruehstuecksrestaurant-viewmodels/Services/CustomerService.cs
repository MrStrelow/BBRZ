using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.Models;
using FruehstuecksBestellungMVC.DTOs;
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
        // Wir werfen Exceptions statt "leise" zu scheitern
        var customer = await _context.Customers.FindAsync(orderDto.CustomerId);
        if (customer is null)
        {
            // Dies wird vom globalen Exception Handler (ErrorViewModel) abgefangen
            throw new InvalidOperationException($"Kunde mit der ID {orderDto.CustomerId} konnte nicht gefunden werden.");
        }

        var table = await _context.Tables.FindAsync(orderDto.TableId);
        if (table is null)
        {
            throw new InvalidOperationException($"Tisch mit der ID {orderDto.TableId} konnte nicht gefunden werden.");
        }

        var menus = await _context.Menus.Where(m => orderDto.SelectedMenuIds.Contains(m.Id)).ToListAsync();
        var dishes = await _context.Dishes.Where(d => orderDto.SelectedDishIds.Contains(d.Id)).ToListAsync();

        // Diese Prüfung ist jetzt redundant, da sie im DTO erfolgt,
        // Wir vertrauen auf die validierung des controllers.
        //if (!menus.Any() && !dishes.Any())
        //    return;
        // Falls es sehr kritische abfragen sind, können wir die auch doppelt im service machen.

        var visit = new Visit { EntryTime = DateTime.UtcNow, Table = table, Customers = { customer } };
        _context.Visits.Add(visit);

        var order = new Order { OrderTime = DateTime.UtcNow, Visit = visit, Menus = menus, Dishes = dishes };
        _context.Orders.Add(order);

        decimal totalAmount = menus.Sum(m => m.Price) + dishes.Sum(d => d.Price);

        var bill = new Bill { TotalAmount = totalAmount, BillDate = DateTime.UtcNow, Visit = visit };
        _context.Bills.Add(bill);

        await _context.SaveChangesAsync();
    }
}