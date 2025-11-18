using Aufgabe_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_1.Configuration;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.HasOne(f => f.Pilot)                    
               .WithMany(p => p.GeflogeneFlügePilot)        
               .HasForeignKey(f => f.PilotId)     
               .OnDelete(DeleteBehavior.Restrict);       // verbiete cascade beim Löschen

        builder.HasOne(f => f.CoPilot)                   
               .WithMany(p => p.GeflogeneFlügeCopilot)        
               .HasForeignKey(f => f.CoPilotId)         
               .OnDelete(DeleteBehavior.Restrict);       // verbiete cascade beim Löschen
    }
}
