using Fruehstuecksrestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace Fruehstuecksrestaurant.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Für login über den microsoft user
        //optionsBuilder.UseSqlServer(@"Server=C432-LT-A7A3\SQLEXPRESS;Database=restaurant;Trusted_Connection=True;Trust Server Certificate=True");

        // Für login direkt auf dem sql server
        optionsBuilder.UseSqlServer(@"Data Source=C432-LT-A7A3\SQLEXPRESS;Database=fruehstueckdb;Trust Server Certificate=True");
    }
}
