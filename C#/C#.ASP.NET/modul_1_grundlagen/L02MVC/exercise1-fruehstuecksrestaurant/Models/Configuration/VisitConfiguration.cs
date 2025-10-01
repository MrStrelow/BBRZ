using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksBestellungMVC.Data.Configurations;

public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.HasKey(v => v.VisitId);

        builder.HasOne(v => v.Bill)
               .WithOne(b => b.Visit)
               .HasForeignKey<Bill>(b => b.VisitId);

        builder.HasMany(v => v.Orders)
               .WithOne(o => o.Visit)
               .HasForeignKey(o => o.VisitId);
    }
}