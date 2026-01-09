using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksBestellungMVC.Data.Configurations;

public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.HasKey(v => v.Id);

        // muss angegeben werden, und ist automatisch aktuelle datum.
        builder.Property(v => v.EntryTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        // Wird beim Verlassen angegeben, ist im nachhinein festzulegen.
        builder.Property(v => v.ExitTime)
            .HasColumnType("datetime")
            .IsRequired(false); // nicht notwendig, sagt aber dass explizit es nicht angegeben werden muss.

        builder.HasOne(v => v.Bill)
               .WithOne(b => b.Visit)
               .HasForeignKey<Bill>(b => b.VisitId);

        builder.HasMany(v => v.Customers)
               .WithMany(c => c.Visits);

        builder.HasOne(v => v.Table)
               .WithMany(t => t.Visits)
               .HasForeignKey(v => v.TableId);

        builder.HasMany(v => v.Orders)
               .WithOne(o => o.Visit)
               .HasForeignKey(o => o.VisitId);
    }
}