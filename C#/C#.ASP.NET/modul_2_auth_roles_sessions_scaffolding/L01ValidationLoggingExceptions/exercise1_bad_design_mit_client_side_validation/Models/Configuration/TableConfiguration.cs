using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksBestellungMVC.Data.Configurations;

public class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.TableNumber).IsRequired().HasMaxLength(30);
        builder.Property(t => t.Seats).IsRequired().HasColumnType("tinyint"); // 256 zustände.
        // 1-n beziehung bereits in table configuriert.
    }
}