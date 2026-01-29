using FruehstuecksBestellungMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Neu
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FruehstuecksBestellungMVC.Data;

// Änderung: Erbt von IdentityDbContext statt DbContext
public class ApplicationDbContext : IdentityDbContext
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

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Wichtig für Identity Keys!
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}