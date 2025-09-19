using Microsoft.EntityFrameworkCore;

namespace Beziehungen.Data;

public class MyDbContext : DbContext
{
    // erstelle ein DBSet von Dishes als Eigenschaft

    // erstelle ein DBSet von Ingredients als Eigenschaft
    // erstelle ein DBSet von Preperationsteps als Eigenschaft

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=C432-LT-A7A3\SQLEXPRESS;Database=beziehungen_live;User ID=sa;Password=qwertz011235;Trust Server Certificate=True");
    }
}
