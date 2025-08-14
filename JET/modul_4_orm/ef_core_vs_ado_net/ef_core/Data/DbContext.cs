using Fruehstuecksrestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace Fruehstuecksrestaurant.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FruehstuecksrestaurantConsole;Trusted_Connection=True;");
        optionsBuilder.UseSqlServer(@"Data Source=C432-LT-A7A3\SQLEXPRESS;Initial Catalog=fruehstueckdb;User ID=sa;Password=qwertz011235;Trust Server Certificate=True");
    }
}