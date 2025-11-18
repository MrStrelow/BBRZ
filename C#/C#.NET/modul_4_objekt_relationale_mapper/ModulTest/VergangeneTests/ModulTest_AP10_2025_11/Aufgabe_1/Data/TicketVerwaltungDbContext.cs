using Aufgabe_1.Configuration;
using Aufgabe_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_1.Data;

public class TicketVerwaltungDbContext : DbContext
{
    public DbSet<Airline> Airlines { get; set; }
    public DbSet<Airplane> Airplanes { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Gate> Gates { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Pilot> Pilots { get; set; }
    public DbSet<Terminal> Terminals { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=C432-LT-A7A3\SQLEXPRESS;Database=TestAufgabe1Und2;User ID=sa;Password=qwertz011235;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FlightConfiguration());
        //base.OnModelCreating(modelBuilder);
    }
}
