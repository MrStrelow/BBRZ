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
        optionsBuilder.UseSqlServer(@"Data Source=C432-LT-A7A3\SQLEXPRESS;Database=anotherfruehstueckdb;User ID=sa;Password=qwertz011235;Trust Server Certificate=True");
    }
}

    