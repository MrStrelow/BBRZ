// Controllers/DashboardController.cs
using FruehstuecksBestellungMVC.Data;
using Microsoft.AspNetCore.Mvc;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        // Lädt nur die globalen Daten (z.B. Rechnungsliste für unten/rechts)
        var bills = await _context.Bills
            .Include(b => b.Visit)
            .Include(b => b.Delivery) //
            .OrderByDescending(b => b.BillDate)
            .ToListAsync();

        return View(bills);
    }
}