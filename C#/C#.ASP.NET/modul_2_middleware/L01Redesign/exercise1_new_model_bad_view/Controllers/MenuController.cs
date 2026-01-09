using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.Services;
using FruehstuecksBestellungMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FruehstuecksBestellungMVC.Controllers;

public class MenuController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly MenuService _menuService;

    public MenuController(ApplicationDbContext context, MenuService menuService)
    {
        _context = context;
        _menuService = menuService;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var viewModel = new MenuViewModel();
        viewModel.AvailableDishes = await _context.Dishes.ToListAsync();
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MenuViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            // Wenn das Formular ungültig ist, zeigen wir das Formular erneut an.
            return View(viewModel);
        }

        var newDish = await _menuService.CreateMenu(viewModel.ToDto());

        return RedirectToAction(nameof(FruehstueckController.Index), "Fruehstueck");
    }
}
