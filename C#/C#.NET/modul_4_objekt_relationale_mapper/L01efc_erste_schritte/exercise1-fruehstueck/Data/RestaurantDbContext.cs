using FruehstuecksrestaurantMore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FruehstuecksrestaurantMore.Data;

public class RestaurantDbContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<PreparationStep> PreparationSteps { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<Table> Tables { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=C432-LT-A7A3\SQLEXPRESS;Database=exercise1-fruehstueck;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Diese Zeile scannt das gesamte Projekt nach Klassen, die IEntityTypeConfiguration
        // implementieren, und wendet sie automatisch an.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestaurantDbContext).Assembly);
    }
}