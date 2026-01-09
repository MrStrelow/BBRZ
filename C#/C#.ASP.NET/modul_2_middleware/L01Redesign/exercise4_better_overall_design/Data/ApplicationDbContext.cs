using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FruehstuecksBestellungMVC.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<PreparationStep> PreparationSteps { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<TakeAway> TakeAways { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}