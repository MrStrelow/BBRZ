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

    public async Task CreateOrderAsync(int customerId, int tableId, List<int> menuIds, List<int> dishIds)
    {
        var customer = await _context.Customers.FindAsync(customerId);
        var table = await _context.Tables.FindAsync(tableId);

        // Vermeide leere Listen, um EF Core Abfragen mit leeren `IN` Klauseln zu verhindern
        var menus = menuIds.Any() ? await _context.Menus.Where(m => menuIds.Contains(m.Id)).ToListAsync() : new List<Menu>();
        var dishes = dishIds.Any() ? await _context.Dishes.Where(d => dishIds.Contains(d.Id)).ToListAsync() : new List<Dish>();


        if (customer == null || table == null || (!menus.Any() && !dishes.Any()))
        {
            return; // Ungültige Eingabe
        }

        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var visit = new Visit { EntryTime = DateTime.UtcNow, Table = table, Customers = { customer } };
            _context.Visits.Add(visit);

            var order = new Order { OrderTime = DateTime.UtcNow, Visit = visit, Menus = menus, Dishes = dishes };
            _context.Orders.Add(order);

            // Berechne den Gesamtbetrag aus Menüs und einzelnen Gerichten
            decimal totalAmount = menus.Sum(m => m.Price) + dishes.Sum(d => d.Price);

            var bill = new Bill { TotalAmount = totalAmount, BillDate = DateTime.UtcNow, Visit = visit };
            _context.Bills.Add(bill);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}