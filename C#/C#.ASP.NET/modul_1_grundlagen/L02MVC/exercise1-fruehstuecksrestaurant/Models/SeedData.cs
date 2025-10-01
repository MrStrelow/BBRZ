using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FruehstuecksBestellungMVC.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Beenden, wenn bereits Daten vorhanden sind (hier anhand der Tische geprüft)
                if (await context.Tables.AnyAsync())
                {
                    return;
                }

                // =================================================================
                // 1. Unabhängige Entitäten erstellen (Ingredients, PreparationStep, Tables)
                // =================================================================

                // -- 2 Customers --
                var customers = new Customer[]
                {
                    new Customer { Name = "Anna Weber" },
                    new Customer { Name = "Markus Huber" }
                };
                await context.Customers.AddRangeAsync(customers);

                // -- 40 Ingredients --
                var salz = new Ingredient { Name = "Salz" };
                var pfeffer = new Ingredient { Name = "Pfeffer" };
                var olivenoel = new Ingredient { Name = "Olivenöl" };
                var butter = new Ingredient { Name = "Butter" };
                var ei = new Ingredient { Name = "Ei" };
                var milch = new Ingredient { Name = "Milch" };
                var mehl = new Ingredient { Name = "Mehl" };
                var zucker = new Ingredient { Name = "Zucker" };
                var brot = new Ingredient { Name = "Brot" };
                var semmel = new Ingredient { Name = "Semmel" };
                var toast = new Ingredient { Name = "Toast" };
                var croissant = new Ingredient { Name = "Croissant" };
                var bagel = new Ingredient { Name = "Bagel" };
                var schinken = new Ingredient { Name = "Schinken" };
                var speck = new Ingredient { Name = "Speck (Bacon)" };
                var wurst = new Ingredient { Name = "Wurst (Sausage)" };
                var kaese = new Ingredient { Name = "Käse (Gouda)" };
                var frischkaese = new Ingredient { Name = "Frischkäse" };
                var mozzarella = new Ingredient { Name = "Mozzarella" };
                var feta = new Ingredient { Name = "Feta" };
                var raeucherlachs = new Ingredient { Name = "Räucherlachs" };
                var tomate = new Ingredient { Name = "Tomate" };
                var gurke = new Ingredient { Name = "Gurke" };
                var zwiebel = new Ingredient { Name = "Zwiebel" };
                var paprika = new Ingredient { Name = "Paprika" };
                var avocado = new Ingredient { Name = "Avocado" };
                var spinat = new Ingredient { Name = "Spinat" };
                var pilze = new Ingredient { Name = "Champignons" };
                var kartoffel = new Ingredient { Name = "Kartoffel" };
                var salat = new Ingredient { Name = "Blattsalat" };
                var rucola = new Ingredient { Name = "Rucola" };
                var orange = new Ingredient { Name = "Orange" };
                var zitrone = new Ingredient { Name = "Zitrone" };
                var erdbeere = new Ingredient { Name = "Erdbeere" };
                var heidelbeere = new Ingredient { Name = "Heidelbeere" };
                var banane = new Ingredient { Name = "Banane" };
                var apfel = new Ingredient { Name = "Apfel" };
                var joghurt = new Ingredient { Name = "Naturjoghurt" };
                var honig = new Ingredient { Name = "Honig" };
                var kaffeebohnen = new Ingredient { Name = "Kaffeebohnen" };

                var ingredients = new[] { salz, pfeffer, olivenoel, butter, ei, milch, mehl, zucker, brot, semmel, toast, croissant, bagel, schinken, speck, wurst, kaese, frischkaese, mozzarella, feta, raeucherlachs, tomate, gurke, zwiebel, paprika, avocado, spinat, pilze, kartoffel, salat, rucola, orange, zitrone, erdbeere, heidelbeere, banane, apfel, joghurt, honig, kaffeebohnen };
                await context.Ingredients.AddRangeAsync(ingredients);

                // -- 20 PreparationStep --
                var gemueseWaschen = new PreparationStep { Description = "Gemüse waschen und trocknen", StepOrder = 1 };
                var inScheibenSchneiden = new PreparationStep { Description = "In Scheiben schneiden", StepOrder = 2 };
                var wuerfeln = new PreparationStep { Description = "In kleine Würfel schneiden", StepOrder = 2 };
                var eierVerquirlen = new PreparationStep { Description = "Eier in einer Schüssel verquirlen", StepOrder = 1 };
                var speckAnbraten = new PreparationStep { Description = "Speck in der Pfanne knusprig anbraten", StepOrder = 1 };
                var brotToasten = new PreparationStep { Description = "Brot goldbraun toasten", StepOrder = 1 };
                var kaffeeMahlen = new PreparationStep { Description = "Kaffeebohnen frisch mahlen", StepOrder = 1 };
                var kaffeeBruehen = new PreparationStep { Description = "Kaffee aufbrühen", StepOrder = 2 };
                var saftPressen = new PreparationStep { Description = "Früchte auspressen", StepOrder = 1 };
                var butterSchmelzen = new PreparationStep { Description = "Butter in einer Pfanne schmelzen", StepOrder = 1 };
                var anrichten = new PreparationStep { Description = "Auf einem Teller anrichten", StepOrder = 10 };
                var garnieren = new PreparationStep { Description = "Mit frischen Kräutern garnieren", StepOrder = 11 };
                var wuerzen = new PreparationStep { Description = "Mit Salz und Pfeffer würzen", StepOrder = 9 };
                var aufstrichVerteilen = new PreparationStep { Description = "Aufstrich gleichmäßig verteilen", StepOrder = 3 };
                var schichten = new PreparationStep { Description = "Zutaten schichten", StepOrder = 4 };
                var backen = new PreparationStep { Description = "Im Ofen bei 180°C backen", StepOrder = 5 };
                var pochieren = new PreparationStep { Description = "Ei für 3 Minuten pochieren", StepOrder = 3 };
                var sautieren = new PreparationStep { Description = "Gemüse in der Pfanne sautieren", StepOrder = 3 };
                var fruechteSchneiden = new PreparationStep { Description = "Früchte in mundgerechte Stücke schneiden", StepOrder = 1 };
                var vermengen = new PreparationStep { Description = "Alle Zutaten in einer Schüssel vermengen", StepOrder = 4 };

                var preperationSteps = new[] { gemueseWaschen, inScheibenSchneiden, wuerfeln, eierVerquirlen, speckAnbraten, brotToasten, kaffeeMahlen, kaffeeBruehen, saftPressen, butterSchmelzen, anrichten, garnieren, wuerzen, aufstrichVerteilen, schichten, backen, pochieren, sautieren, fruechteSchneiden, vermengen };
                await context.PreparationSteps.AddRangeAsync(preperationSteps);

                // -- 5 Tables --
                var tables = new Table[]
                {
                    new Table { TableNumber = "S1", Seats = 8 },
                    new Table { TableNumber = "S2", Seats = 4 },
                    new Table { TableNumber = "G1", Seats = 4 },
                    new Table { TableNumber = "G2", Seats = 4 },
                    new Table { TableNumber = "B1", Seats = 6 }
                };
                await context.Tables.AddRangeAsync(tables);

                // =================================================================
                // 2. Abhängige Entitäten erstellen (Dishes, Menus)
                // =================================================================

                // -- 10 Dishes --
                var wienerFruehstueck = new Dish
                {
                    Name = "Wiener Frühstück",
                    Price = 8.50m,
                    Ingredients = { semmel, butter, schinken, kaese },
                    PreparationSteps = { anrichten }
                };
                var englishBreakfast = new Dish
                {
                    Name = "English Breakfast",
                    Price = 14.00m,
                    Ingredients = { ei, speck, wurst, toast, pilze },
                    PreparationSteps = { speckAnbraten, brotToasten, sautieren, anrichten }
                };
                var avocadoToast = new Dish
                {
                    Name = "Avocado Toast mit pochiertem Ei",
                    Price = 11.50m,
                    Ingredients = { toast, avocado, ei, zitrone, salz, pfeffer },
                    PreparationSteps = { brotToasten, pochieren, wuerzen, anrichten, garnieren }
                };
                var lachsBagel = new Dish
                {
                    Name = "Lachs-Bagel",
                    Price = 12.00m,
                    Ingredients = { bagel, raeucherlachs, frischkaese, zwiebel },
                    PreparationSteps = { brotToasten, inScheibenSchneiden, aufstrichVerteilen, schichten, anrichten }
                };
                var JoghurtBowl = new Dish
                {
                    Name = "Joghurt Bowl mit Früchten",
                    Price = 9.00m,
                    Ingredients = { joghurt, honig, erdbeere, heidelbeere, banane },
                    PreparationSteps = { fruechteSchneiden, vermengen, anrichten }
                };
                var bauernomelett = new Dish
                {
                    Name = "Bauernomelett",
                    Price = 10.50m,
                    Ingredients = { ei, kartoffel, zwiebel, speck, salz, pfeffer },
                    PreparationSteps = { wuerfeln, speckAnbraten, eierVerquirlen, sautieren, wuerzen, anrichten }
                };
                var croissantDeluxe = new Dish
                {
                    Name = "Croissant Deluxe",
                    Price = 7.50m,
                    Ingredients = { croissant, schinken, kaese, tomate },
                    PreparationSteps = { inScheibenSchneiden, schichten, backen, anrichten }
                };
                var caprese = new Dish
                {
                    Name = "Caprese-Sticks",
                    Price = 6.00m,
                    Ingredients = { tomate, mozzarella, olivenoel, pfeffer },
                    PreparationSteps = { gemueseWaschen, inScheibenSchneiden, schichten, anrichten, garnieren }
                };
                var kaffeeCrema = new Dish
                {
                    Name = "Kaffee Crema",
                    Price = 3.50m,
                    Ingredients = { kaffeebohnen },
                    PreparationSteps = { kaffeeMahlen, kaffeeBruehen }
                };
                var frischGepressterOJ = new Dish
                {
                    Name = "Frisch gepresster Orangensaft",
                    Price = 4.50m,
                    Ingredients = { orange },
                    PreparationSteps = { saftPressen }
                };

                var dishes = new[] { wienerFruehstueck, englishBreakfast, avocadoToast, lachsBagel, JoghurtBowl, bauernomelett, croissantDeluxe, caprese, kaffeeCrema, frischGepressterOJ };
                await context.Dishes.AddRangeAsync(dishes);

                // -- 2 Menus --
                var klassikerMenue = new Menu
                {
                    Name = "Menü 'Klassiker'",
                    Price = 11.00m, // Deal-Preis
                    Dishes = { wienerFruehstueck, kaffeeCrema }
                };

                var vitalMenue = new Menu
                {
                    Name = "Menü 'Vital'",
                    Price = 14.50m, // Deal-Preis
                    Dishes = { JoghurtBowl, frischGepressterOJ }
                };

                var menus = new[] { klassikerMenue, vitalMenue };
                await context.Menus.AddRangeAsync(menus);

                // =================================================================
                // 3. Änderungen speichern
                // =================================================================
                await context.SaveChangesAsync();
            }
        }
    }
}