using Beziehungen.Models;
using Microsoft.EntityFrameworkCore;

namespace Beziehungen.Data;

public class MyDbContext : DbContext
{
    // erstelle ein DBSet von Dishes als Eigenschaft
    DbSet<Dish> Dishes { get; set; }

    // erstelle ein DBSet von Ingredients als Eigenschaft
    DbSet<Ingredient> Ingredients { get; set; } 

    // erstelle ein DBSet von Preperationsteps als Eigenschaft
    DbSet<PreparationStep> PreparationSteps { get; set; }

    // erstelle ein DBSet von Visits als Eigenschaft
    DbSet<Visit> Visits { get; set; }

    // erstelle ein DBSet von Customer als Eigenschaft
    DbSet<Customer> Customer { get; set; }

    // erstelle ein DBSet von Table als Eigenschaft
    DbSet<Table> Table { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=C432-LT-A7A3\SQLEXPRESS;Database=beziehungen_live;User ID=sa;Password=qwertz011235;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
    }
}
