using DemoEfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEfCore.Data;

// DbContext: "Session der Database"
internal class PizzaContext : DbContext
{
    // DbSet maps zu einer Tabelle in der Datanbank.
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    public DbSet<ImportantProductsView> ImportantProductsViews { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // durch EF Core SQL package -> UseSQLServer möglich
        // @ bedeutet literal String -> \ werden nicht als escape gesehen.
        optionsBuilder.UseSqlServer(@"Data Source=C432-LT-A7A3\SQLEXPRESS;Initial Catalog=demodb;User ID=sa;Password=qwertz011235;Trust Server Certificate=True");
            //.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
            //.EnableSensitiveDataLogging();
        
        //Logging und sensitivedatalogging nützlich in development abaer nicht in production!

        // base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ImportantProductsView>(entity =>
        {
            entity.HasNoKey(); 
            entity.ToView("ImportantProductsView");
        });
    }


}
