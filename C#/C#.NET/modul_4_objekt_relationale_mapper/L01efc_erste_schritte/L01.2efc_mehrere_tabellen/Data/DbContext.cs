using FruehstuecksrestaurantMore.Models;
using Microsoft.EntityFrameworkCore;

namespace FruehstuecksrestaurantMore.Data;

public class ApplicationDbContext : DbContext
{
    // DbSets für die neuen Entitäten
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<PreparationStep> PreparationSteps { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=C432-LT-A7A3\SQLEXPRESS;Database=anotherfruehstueckdb;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // -- 1. ZUTATEN (Ingredients) --
        // Wir müssen explizite IDs vergeben, um später darauf verweisen zu können.
        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient { Id = 1, Name = "Eier", Unit = "Stück" },
            new Ingredient { Id = 2, Name = "Mehl", Unit = "g" },
            new Ingredient { Id = 3, Name = "Zucker", Unit = "g" },
            new Ingredient { Id = 4, Name = "Milch", Unit = "ml" },
            new Ingredient { Id = 5, Name = "Salz", Unit = "Prise" }
        );

        // -- 2. GERICHTE (Dishes) --
        // Auch hier müssen wir IDs vergeben.
        modelBuilder.Entity<Dish>().HasData(
            new Dish { Id = 1, Name = "Spiegelei", Description = "Ein einfaches Spiegelei mit Salz." },
            new Dish { Id = 2, Name = "Pfannkuchen", Description = "Ein süßer Klassiker." }
        );

        // -- 3. ZUBEREITUNGSSCHRITTE (PreparationSteps) --
        // Hier müssen wir ebenfalls IDs für die Schritte selbst und den
        // Fremdschlüssel 'MoreDishId' zum jeweiligen Gericht angeben.
        // Wir verwenden hier ein Anonymes Objekt das MoreDishId ein shadowproperty ist.
        modelBuilder.Entity<PreparationStep>().HasData(
            // Schritte für Spiegelei (DishId = 1)
            new { Id = 1, StepNumber = 1, Instruction = "Pfanne erhitzen.", MoreDishId = 1 },
            new { Id = 2, StepNumber = 2, Instruction = "Ei in die Pfanne schlagen.", MoreDishId = 1 },
            new { Id = 3, StepNumber = 3, Instruction = "Mit Salz würzen.", MoreDishId = 1 },

            // Schritte für Pfannkuchen (DishId = 2)
            new { Id = 4, StepNumber = 1, Instruction = "Mehl, Zucker, Milch und Eier zu einem Teig verrühren.", MoreDishId = 2 },
            new { Id = 5, StepNumber = 2, Instruction = "Etwas Teig in eine heiße Pfanne geben.", MoreDishId = 2 },
            new { Id = 6, StepNumber = 3, Instruction = "Von beiden Seiten goldbraun backen.", MoreDishId = 2 }
        );


        // -- 4. VERKNÜPFUNG ZUTATEN <-> GERICHTE (n:m Beziehung) --
        // Für das Seeding mit HasData ist dies der einzig mögliche Weg.
        // Wir müssen die Zwischentabelle direkt mit den Fremdschlüsseln befüllen.
        modelBuilder.Entity("DishIngredient").HasData(
            // Die Spaltennamen müssen exakt den Namen der Navigationseigenschaften
            // im Plural + "Id" entsprechen, die EF Core generiert.
            // In deinem Fall sind das "MoreDishesId" und "IngredientsId".
            new { MoreDishesId = 1, IngredientsId = 1 }, // Spiegelei (1) -> Eier (1)
            new { MoreDishesId = 1, IngredientsId = 5 }, // Spiegelei (1) -> Salz (5)

            new { MoreDishesId = 2, IngredientsId = 1 }, // Pfannkuchen (2) -> Eier (1)
            new { MoreDishesId = 2, IngredientsId = 2 }, // Pfannkuchen (2) -> Mehl (2)
            new { MoreDishesId = 2, IngredientsId = 3 }, // Pfannkuchen (2) -> Zucker (3)
            new { MoreDishesId = 2, IngredientsId = 4 }  // Pfannkuchen (2) -> Milch (4)
        );
    }
}

    