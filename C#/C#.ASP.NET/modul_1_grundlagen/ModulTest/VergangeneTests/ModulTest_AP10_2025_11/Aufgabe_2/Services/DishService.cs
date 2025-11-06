using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.DTOs;
using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FruehstuecksBestellungMVC.Services
{
    public class DishService
    {
        private readonly ApplicationDbContext _dbContext;

        public DishService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dish> CreateDish(DishDto dishDto)
        {
            // 1. Standard-Zutaten und Schritte holen
            var defaultIngredient = await _dbContext.Ingredients.FirstOrDefaultAsync();
            var defaultStep = await _dbContext.PreparationSteps.FirstOrDefaultAsync();

            // 2. Neues Model-Objekt erstellen
            var newDish = new Dish
            {
                Name = dishDto.Name,
                Price = dishDto.Price, 
                Ingredients = new List<Ingredient>(),
                PreparationSteps = new List<PreparationStep>()
            };

            // 3. Beziehungen hinzufügen 
            if (defaultIngredient is not null)
            {
                newDish.Ingredients.Add(defaultIngredient);
            }

            if (defaultStep is not null)
            {
                newDish.PreparationSteps.Add(defaultStep);
            }

            // 4. Save Changes in Db
            _dbContext.Dishes.Add(newDish);
            await _dbContext.SaveChangesAsync();

            // 5. Das erstellte Objekt zurückgeben
            return newDish;
        }
    }
}