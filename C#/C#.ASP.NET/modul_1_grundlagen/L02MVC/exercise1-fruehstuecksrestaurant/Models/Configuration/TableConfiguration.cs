using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksBestellungMVC.Data.Configurations;

public class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(t => t.TableId);
        builder.Property(t => t.Name).IsRequired().HasMaxLength(50);

        builder.HasMany(t => t.Visits)
               .WithOne(v => v.Table)
               .HasForeignKey(v => v.TableId);
    }
}