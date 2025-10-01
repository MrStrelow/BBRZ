using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FruehstuecksBestellungMVC.Controllers;

public class FruehstueckController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly CustomerService _customerService;

    public FruehstueckController(ApplicationDbContext context, CustomerService customerService)
    {
        _context = context;
        _customerService = customerService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Title = "Frühstücksbestellung";
        ViewBag.Customers = new SelectList(await _context.Customers.ToListAsync(), "Id", "Name");
        ViewBag.Tables = new SelectList(await _context.Tables.ToListAsync(), "Id", "TableNumber");
        ViewBag.Menus = await _context.Menus.ToListAsync();
        ViewBag.Dishes = await _context.Dishes.ToListAsync(); // Für a la carte

        var bills = await _context.Bills
            .Include(b => b.Visit).ThenInclude(v => v.Table)
            .Include(b => b.Visit).ThenInclude(v => v.Customers)
            .Include(b => b.Visit).ThenInclude(v => v.Orders).ThenInclude(o => o.Menus)
            .Include(b => b.Visit).ThenInclude(v => v.Orders).ThenInclude(o => o.Dishes)
            .OrderByDescending(b => b.BillDate)
            .ToListAsync();

        return View(bills);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Bestellen(int customerId, int tableId, List<int> selectedMenuIds, List<int> selectedDishIds)
    {
        if (ModelState.IsValid && (selectedMenuIds.Any() || selectedDishIds.Any()))
        {
            await _customerService.CreateOrderAsync(customerId, tableId, selectedMenuIds, selectedDishIds);
            return RedirectToAction(nameof(Index));
        }

        // Bei Fehler: Seite neu laden mit Fehlermeldung
        ViewBag.Title = "Frühstücksbestellung";
        ViewBag.Customers = new SelectList(await _context.Customers.ToListAsync(), "Id", "Name", customerId);
        ViewBag.Tables = new SelectList(await _context.Tables.ToListAsync(), "Id", "TableNumber", tableId);
        ViewBag.Menus = await _context.Menus.ToListAsync();
        ViewBag.Dishes = await _context.Dishes.ToListAsync();
        ViewBag.ErrorMessage = "Bestellung ungültig. Bitte wählen Sie einen Kunden, Tisch und mindestens ein Menü oder Gericht.";

        var bills = await _context.Bills.ToListAsync();
        return View("Index", bills);
    }
}