// Data/RestaurantDbContext.cs
using Microsoft.EntityFrameworkCore;
using MorgenstundRestaurant.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MorgenstundRestaurant.Data;

public class RestaurantDbContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<StockItem> Stock { get; set; }
    public DbSet<Bill> Bills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=C432-LT-A7A3\SQLEXPRESS;Database=efcex1;User ID=sa;Password=qwertz011235;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Lagerbestand anlegen
        modelBuilder.Entity<StockItem>().HasData(
            new StockItem { Id = 1, Name = "Ei", Quantity = 100 },
            new StockItem { Id = 2, Name = "Kaffeebohnen", Quantity = 50 },
            new StockItem { Id = 3, Name = "Croissant-Teigling", Quantity = 40 },
            new StockItem { Id = 4, Name = "Orange", Quantity = 60 }
        );
    }
}