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
        private readonly ApplicationDbContext _context;

        public DishController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var dish = await _context.Dishes
                .Include(d => d.Ingredients)
                .Include(d => d.PreparationSteps)
                .FirstOrDefaultAsync(d => d.Id == id);

            var viewModel = new DishViewModel
            {
                Id = dish.Id,
                Name = dish.Name,
                Price = dish.Price,
                Ingredients = dish.Ingredients,
                Preparationstep = dish.PreparationSteps
            };

            return View(viewModel);
        }
    }
}