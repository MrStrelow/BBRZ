using Fruehstuecksrestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace Fruehstuecksrestaurant.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Für login über den microsoft user
        optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=restaurant;Trusted_Connection=True; Trust Server Certificate=True");
    }
}
