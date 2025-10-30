using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FruehstuecksBestellungMVC.Services;

public class CustomerService
{
    private readonly ApplicationDbContext _context;

    public CustomerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateOrderAsync(int? customerId, int? tableId, List<int> menuIds, List<int> dishIds)
    {
        // Wir werfen Exceptions statt "leise" zu scheitern
        var customer = await _context.Customers.FindAsync(customerId);
        if (customer is null)
        {
            // Dies wird vom globalen Exception Handler (ErrorViewModel) abgefangen
            throw new InvalidOperationException($"Kunde mit der ID {customerId} konnte nicht gefunden werden.");
        }

        var table = await _context.Tables.FindAsync(tableId);
        if (table is null)
        {
            throw new InvalidOperationException($"Tisch mit der ID {tableId} konnte nicht gefunden werden.");
        }

        var menus = menuIds.Any() ? await _context.Menus.Where(m => menuIds.Contains(m.Id)).ToListAsync() : new List<Menu>();
        var dishes = dishIds.Any() ? await _context.Dishes.Where(d => dishIds.Contains(d.Id)).ToListAsync() : new List<Dish>();

        // Diese Prüfung ist jetzt redundant, da sie im DTO erfolgt,
        // aber ein Service sollte sich immer selbst schützen.
        if (!menus.Any() && !dishes.Any())
            return;

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