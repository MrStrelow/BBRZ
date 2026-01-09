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

    private async Task PopulateViewModelAsync(FruehstueckViewModel viewModel)
    {
        viewModel.Menus = await _context.Menus.ToListAsync();
        viewModel.Dishes = await _context.Dishes.ToListAsync();
        viewModel.Customers = new SelectList(await _context.Customers.ToListAsync(), "Id", "Name");
        viewModel.Tables = new SelectList(await _context.Tables.ToListAsync(), "Id", "TableNumber");
        viewModel.Bills = await _context.Bills
            // 1. Visit Daten laden
            .Include(b => b.Visit).ThenInclude(v => v.Table)
            .Include(b => b.Visit).ThenInclude(v => v.Customers)
            .Include(b => b.Visit).ThenInclude(v => v.Orders).ThenInclude(o => o.Menus)
            .Include(b => b.Visit).ThenInclude(v => v.Orders).ThenInclude(o => o.Dishes)

            // 2. Delivery Daten laden
            .Include(b => b.Delivery).ThenInclude(d => d.Customer) // Kunden laden
            .Include(b => b.Delivery).ThenInclude(d => d.Order).ThenInclude(o => o.Menus)
            .Include(b => b.Delivery).ThenInclude(d => d.Order).ThenInclude(o => o.Dishes)

            // 3. TakeAway Daten laden
            .Include(b => b.TakeAway).ThenInclude(t => t.Customer) // Kunden laden
            .Include(b => b.TakeAway).ThenInclude(t => t.Orders).ThenInclude(o => o.Menus)
            .Include(b => b.TakeAway).ThenInclude(t => t.Orders).ThenInclude(o => o.Dishes)

            .OrderByDescending(b => b.BillDate)
            .ToListAsync();
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? error)
    {
        ViewBag.Title = "Frühstücksbestellung";

        // Wenn ein Error übergeben wurde (z.B. von der Middleware), fügen wir ihn hinzu
        if (!string.IsNullOrEmpty(error))
        {
            // Fügt den Fehler dem ModelState hinzu, damit asp-validation-summary ihn anzeigt
            ModelState.AddModelError("", error);
        }

        // Ersetzt das Tupel: Ein sauberes ViewModel erstellen
        var viewModel = new FruehstueckViewModel();

        // Das ViewModel mit allen Daten für die Listen füllen
        await PopulateViewModelAsync(viewModel);

        return View("Index", viewModel);
    }


    [HttpPost]
    public async Task<IActionResult> BestellenTakeIn(TakeInOrderViewModel vm)
    {
        if (!ModelState.IsValid) return await ReloadIndexWithErrors(vm);

        // Hier idealerweise auch den Service splitten oder spezialisierte DTOs übergeben
        await _customerService.CreateTakeInOrderAsync(vm.ToDto());
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> BestellenDelivery(DeliveryOrderViewModel vm)
    {
        if (!ModelState.IsValid) return await ReloadIndexWithErrors(vm);

        await _customerService.CreateDeliveryOrderAsync(vm.ToDto());
        return RedirectToAction(nameof(Index));
    }

    // Hilfsmethode um Codeduplikate beim Fehlerfall zu vermeiden
    private async Task<IActionResult> ReloadIndexWithErrors(OrderViewModel specificVm)
    {
        var mainVm = new FruehstueckViewModel();
        await PopulateViewModelAsync(mainVm);

        // Wir müssen die fehlerhaften Eingaben zurück in das MainViewModel mappen,
        // damit der User sie nicht neu eingeben muss.
        if (specificVm is TakeInOrderViewModel t) mainVm.TakeInOrder = t;
        if (specificVm is DeliveryOrderViewModel d) mainVm.DeliveryOrder = d;
        // ...

        return View("Index", mainVm);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    // Bind Prefix "Order" ist wichtig, da im ViewModel die Property "Order" heißt
    public async Task<IActionResult> Bestellen([Bind(Prefix = "Order")] OrderViewModel orderViewModel)
    {
        if (!ModelState.IsValid)
        {
            var vm = new FruehstueckViewModel();
            await PopulateViewModelAsync(vm);
            vm.Order = orderViewModel; // User-Eingaben erhalten
            return View("Index", vm);
        }

        try
        {
            await _customerService.CreateOrderAsync(new OrderDto(orderViewModel));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Fehler beim Speichern: " + ex.Message);
            var vm = new FruehstueckViewModel();
            await PopulateViewModelAsync(vm);
            vm.Order = orderViewModel;
            return View("Index", vm);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> ManageDelivery(int deliveryId)
    {
        var delivery = await _context.Deliveries
            .Include(d => d.Customer)
            .Include(d => d.Order)
            .FirstOrDefaultAsync(d => d.Id == deliveryId);

        if (delivery == null) return NotFound();

        var vm = new DeliveryManagementViewModel
        {
            DeliveryId = delivery.Id,
            OrderId = delivery.Order?.Id ?? 0,
            CustomerName = delivery.Customer?.Name ?? "Unbekannt",
            OrderDate = delivery.CreatedDate,
            ExpectedDeliveryDate = delivery.ExpectedDeliveryDate,
            ActualDeliveryDate = delivery.ActualDeliveryDate,
            DeliveryComment = delivery.DeliveryComment,
            ExistingImagePath = delivery.DeliveryImagePath,
            IsCanceled = delivery.IsCanceled
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateDelivery(DeliveryManagementViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View("ManageDelivery", vm);
        }

        await _customerService.UpdateDeliveryAsync(vm);

        return RedirectToAction(nameof(Index));
    }
}