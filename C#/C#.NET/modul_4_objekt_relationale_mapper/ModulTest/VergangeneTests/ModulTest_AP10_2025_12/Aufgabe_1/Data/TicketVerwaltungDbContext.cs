using Aufgabe_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_1.Data;

public class TicketVerwaltungDbContext : DbContext
{
    public DbSet<Airport> Airports { get; set; }
    public DbSet<BaggageClaim> BaggageClaims { get; set; }
    public DbSet<BoardingPass> BoardingPasses { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Gate> Gates { get; set; }
    public DbSet<Luggage> LuggageItems { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<SecurityCheck> SecurityChecks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Database=TestAufgabe1Und2;Trusted_Connection=True;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Enums als Strings speichern für bessere Lesbarkeit -> sonst nur 0, 1, 2 in der datenbank.
        modelBuilder.Entity<Booking>()
            .Property(b => b.Status)
            .HasConversion<string>(); 

        modelBuilder.Entity<Luggage>()
            .Property(l => l.Status)
            .HasConversion<string>(); 

        modelBuilder.Entity<SecurityCheck>()
            .Property(s => s.Result)
            .HasConversion<string>(); 
    }
}
