using Microsoft.EntityFrameworkCore;
using EFCoreFirstSteps.Model;

namespace EFCoreFirstSteps.Data;

public class MyDbContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }
}
