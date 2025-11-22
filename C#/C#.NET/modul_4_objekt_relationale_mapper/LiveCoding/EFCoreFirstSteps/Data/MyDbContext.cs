using Microsoft.EntityFrameworkCore;
using EFCoreFirstSteps.Model;

namespace EFCoreFirstSteps.Data;

public class MyDbContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Für login über den microsoft user
        optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=restaurant;Trusted_Connection=True;Trust Server Certificate=True");    
    }
}
