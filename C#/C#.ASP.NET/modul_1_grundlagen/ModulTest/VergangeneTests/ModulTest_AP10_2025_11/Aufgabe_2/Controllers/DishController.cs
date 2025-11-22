using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.DTOs;
using FruehstuecksBestellungMVC.Services;
using FruehstuecksBestellungMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FruehstuecksBestellungMVC.Controllers
{
    public class DishController : Controller
    {
        private readonly DishService _dishService;
        private readonly ApplicationDbContext _context;

        public DishController(DishService dishService, ApplicationDbContext context)
        {
            _dishService = dishService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, bool verbose = false)
        {
            // 1. Dish-Model aus der DB laden
            var dish = await _context.Dishes
                .Include(d => d.Ingredients)
                .Include(d => d.PreparationSteps)
                .FirstOrDefaultAsync(d => d.Id == id);

            // 2. ViewModel erstellen und Basis-Eigenschaften befüllen
            var viewModel = new DishViewModel
            {
                Id = dish.Id,
                Name = dish.Name,
                Price = dish.Price
            };

            // 3. "verbose"-Parameter prüfen
            if (verbose)
            {
                viewModel.Ingredients = dish.Ingredients;
                viewModel.Preparationstep = dish.PreparationSteps;
            }

            // 4. Die "Details"-View mit dem ViewModel zurückgeben
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DishViewModel viewModel)
        {
            // 1. Serverseitige Validierung (Attribute + IValidatableObject)
            if (!ModelState.IsValid)
            {
                // Wenn das Formular ungültig ist, zeigen wir das Formular erneut an.
                return View(viewModel);
            }

            // 2. Service aufrufen
            var newDish = await _dishService.CreateDish(viewModel.ToDto());

            // 3. Weiterleiten an die Details-Seite des *neuen* Gerichts
            return RedirectToAction(nameof(Details), new { id = newDish.Id, verbose = true });
        }
    }
}