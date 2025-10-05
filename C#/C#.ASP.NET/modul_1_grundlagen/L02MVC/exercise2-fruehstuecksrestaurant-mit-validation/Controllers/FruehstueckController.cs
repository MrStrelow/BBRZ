using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.Models;
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

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewBag.Title = "Frühstücksbestellung";
        // Schlecht gekapselt: Besser eigens in dem ViewModel/ModelState oder eigener error page. Exceptions werden auch eigens behandelt.
        // Da wir aber keine Fehler anzeigen, lassen wir es ganz weg. Spätere Übungen.
        //ViewBag.ErrorMessage = "Bestellung ungültig. Bitte wählen Sie einen Kunden, Tisch und mindestens ein Menü oder Gericht.";

        // Wir erlauben den Controller mit der Datenbank zu sprechen.
        var menus = await _context.Menus.ToListAsync();
        var dishes = await _context.Dishes.ToListAsync();

        // SelectList macht es leichter mit HTML-Dropdown-Menü (<select>) zu arbeiten.
        var customers = new SelectList(await _context.Customers.ToListAsync(), "Id", "Name");
        var tables = new SelectList(await _context.Tables.ToListAsync(), "Id", "TableNumber");

        var bills = await _context.Bills
            .Include(b => b.Visit).ThenInclude(v => v.Table)
            .Include(b => b.Visit).ThenInclude(v => v.Customers)
            .Include(b => b.Visit).ThenInclude(v => v.Orders).ThenInclude(o => o.Menus)
            .Include(b => b.Visit).ThenInclude(v => v.Orders).ThenInclude(o => o.Dishes)
            .OrderByDescending(b => b.BillDate)
            .ToListAsync();

        // Schlecht gekapselt: Besser wir bauen eine ViewModel! Wir lernen aber erst kennen was das ist.
        var model = (menus, dishes, bills, customers, tables);
        return View("Index", model);
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> Bestellen(int customerId, int tableId, List<int> selectedMenuIds, List<int> selectedDishIds)
    {
        // === Manuelle serverseitige Validierung - Guards ===
        // 1. Prüfen, ob ein gültiger Kunde ausgewählt wurde.
        if (customerId <= 0)
        {
            ModelState.AddModelError("", "Bitte wählen Sie einen Kunden aus.");
        }

        // 2. Prüfen, ob ein gültiger Tisch ausgewählt wurde.
        if (tableId <= 0)
        {
            ModelState.AddModelError("", "Bitte wählen Sie einen Tisch aus.");
        }

        // 3. Prüfen, ob mindestens ein Menü oder Gericht ausgewählt wurde.
        // Die Listen werden vom Model Binder initialisiert, sind also nicht null, können aber leer sein.
        if (selectedMenuIds.Count == 0 && selectedDishIds.Count == 0)
        {
            ModelState.AddModelError("", "Es muss mindestens ein Menü oder ein Gericht ausgewählt werden.");
        }

        // 4. Prüfen, ob die Validierung fehlgeschlagen ist.
        if (!ModelState.IsValid)
        {
            ViewBag.Title = "Fehler bei der Bestellung";

            // WICHTIG: Bei einem Fehler leiten wir nicht um, sondern zeigen die Index-Seite erneut an,
            // damit die Fehlermeldungen angezeigt werden können.
            // Wir erlauben den Controller mit der Datenbank zu sprechen.
            var menus = await _context.Menus.ToListAsync();
            var dishes = await _context.Dishes.ToListAsync();

            // SelectList macht es leichter mit HTML-Dropdown-Menü (<select>) zu arbeiten.
            var customers = new SelectList(await _context.Customers.ToListAsync(), "Id", "Name");
            var tables = new SelectList(await _context.Tables.ToListAsync(), "Id", "TableNumber");

            var bills = await _context.Bills
                .Include(b => b.Visit).ThenInclude(v => v.Table)
                .Include(b => b.Visit).ThenInclude(v => v.Customers)
                .Include(b => b.Visit).ThenInclude(v => v.Orders).ThenInclude(o => o.Menus)
                .Include(b => b.Visit).ThenInclude(v => v.Orders).ThenInclude(o => o.Dishes)
                .OrderByDescending(b => b.BillDate)
                .ToListAsync();

            // Schlecht gekapselt: Besser wir bauen eine ViewModel! Wir lernen aber erst kennen was das ist.
            var model = (menus, dishes, bills, customers, tables);
            return View("Index", model);
        }

        // Wir erlauben es den Controller für größere Aufgaben mit einem Service zu sprechen.
        // Wir erlauben aber auch den Controller für kleinere Aufgaben direkt mit dem Repository/DbContext zu sprechen.
        // schlecht gekapselt: So viele ids, besser wir haben hier ein Objekt wie ein DTO oder ViewModel!
        await _customerService.CreateOrderAsync(customerId, tableId, selectedMenuIds, selectedDishIds);
        return RedirectToAction(nameof(Index));
    }
}