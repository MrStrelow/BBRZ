using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.ViewModels;
using FruehstuecksBestellungMVC.Models;
using FruehstuecksBestellungMVC.Services;
using FruehstuecksBestellungMVC.DTOs;
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

    // NEU: Private Helper-Methode, um doppelten Code zu vermeiden
    private async Task PopulateViewModelAsync(FruehstueckViewModel viewModel)
    {
        viewModel.Menus = await _context.Menus.ToListAsync();
        viewModel.Dishes = await _context.Dishes.ToListAsync();
        viewModel.Customers = new SelectList(await _context.Customers.ToListAsync(), "Id", "Name");
        viewModel.Tables = new SelectList(await _context.Tables.ToListAsync(), "Id", "TableNumber");
        viewModel.Bills = await _context.Bills
            .Include(b => b.Visit).ThenInclude(v => v.Table)
            .Include(b => b.Visit).ThenInclude(v => v.Customers)
            .Include(b => b.Visit).ThenInclude(v => v.Orders).ThenInclude(o => o.Menus)
            .Include(b => b.Visit).ThenInclude(v => v.Orders).ThenInclude(o => o.Dishes)
            .OrderByDescending(b => b.BillDate)
            .ToListAsync();
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewBag.Title = "Frühstücksbestellung";

        // Ersetzt das Tupel: Ein sauberes ViewModel erstellen
        var viewModel = new FruehstueckViewModel();

        // Das ViewModel mit allen Daten für die Listen füllen
        await PopulateViewModelAsync(viewModel);

        return View("Index", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Bestellen([Bind(Prefix = "OrderForm")] CreateOrderDto orderDto)
    {
        // Alle Guards sind jetzt im DTO.
        // Dieser Check prüft automatisch [Annotations] UND die IValidatableObject.Validate-Methode.
        if (!ModelState.IsValid)
        {
            ViewBag.Title = "Fehler bei der Bestellung";

            // Wenn die Validierung fehlschlägt, müssen wir
            // das volle ViewModel neu erstellen, um die Seite erneut anzuzeigen.
            var viewModel = new FruehstueckViewModel();

            // 1. Alle benötigten Daten für das ViewModel laden (Menus, Tables etc.) 
            await PopulateViewModelAsync(viewModel);

            // 2. Das fehlerhafte DTO mit den Benutzereingaben in das VM einfügen,
            //    damit die Auswahl des Benutzers nicht verloren geht.
            viewModel.OrderForm = orderDto;

            return View("Index", viewModel);
        }

        // Bei Erfolg: Daten aus dem DTO an den Service übergeben
        await _customerService.CreateOrderAsync(
            orderDto.CustomerId.Value,
            orderDto.TableId.Value,
            orderDto.SelectedMenuIds,
            orderDto.SelectedDishIds
        );

        return RedirectToAction(nameof(Index));
    }
}