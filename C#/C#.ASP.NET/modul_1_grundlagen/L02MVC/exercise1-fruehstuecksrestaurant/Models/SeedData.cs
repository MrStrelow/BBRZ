using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FruehstuecksBestellungMVC.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            if (context.Tables.Any() || context.Dishes.Any())
            {
                return; // DB has been seeded
            }

            // Tische
            var tables = new Table[]
            {
                new Table { Name = "Tisch 1" },
                new Table { Name = "Tisch 2" },
                new Table { Name = "Fensterplatz 3" },
                new Table { Name = "Sonnenterrasse 4" }
            };
            context.Tables.AddRange(tables);

            // Zutaten
            var zutatEi = new Ingredient { Name = "Ei" };
            var zutatSpeck = new Ingredient { Name = "Speck" };
            var zutatBrot = new Ingredient { Name = "Brot" };
            var zutatButter = new Ingredient { Name = "Butter" };
            var zutatKaese = new Ingredient { Name = "Käse" };
            var zutatSchinken = new Ingredient { Name = "Schinken" };

            context.Ingredients.AddRange(zutatEi, zutatSpeck, zutatBrot, zutatButter, zutatKaese, zutatSchinken);

            // Menü
            var breakfastMenu = new Menu { Name = "Frühstückskarte" };
            context.Menus.Add(breakfastMenu);

            // Gerichte
            var dishes = new Dish[]
            {
                new Dish { Name = "Rührei mit Speck", Price = 7.50m, Menu = breakfastMenu, Ingredients = new List<Ingredient> { zutatEi, zutatSpeck, zutatBrot, zutatButter } },
                new Dish { Name = "Käsebrot", Price = 4.20m, Menu = breakfastMenu, Ingredients = new List<Ingredient> { zutatBrot, zutatButter, zutatKaese } },
                new Dish { Name = "Schinken-Käse-Toast", Price = 5.80m, Menu = breakfastMenu, Ingredients = new List<Ingredient> { zutatBrot, zutatButter, zutatKaese, zutatSchinken } },
                new Dish { Name = "Spiegelei", Price = 3.50m, Menu = breakfastMenu, Ingredients = new List<Ingredient> { zutatEi, zutatButter }}
            };
            context.Dishes.AddRange(dishes);

            context.SaveChanges();
        }
    }
}