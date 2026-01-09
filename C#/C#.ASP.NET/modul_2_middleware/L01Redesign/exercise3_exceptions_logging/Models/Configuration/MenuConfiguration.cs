using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksBestellungMVC.Data.Configurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Price).IsRequired().HasColumnType("decimal(5,2)");

        // n-m zu Dishes
        builder.HasMany(m => m.Dishes)
            .WithMany(d => d.Menus);

        // n-m zu Order
        // bereits in Order configuriert
    }
}