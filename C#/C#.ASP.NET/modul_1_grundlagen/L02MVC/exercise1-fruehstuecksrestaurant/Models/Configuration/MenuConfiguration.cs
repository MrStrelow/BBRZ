using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksBestellungMVC.Data.Configurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(m => m.MenuId);
        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);

        builder.HasMany(m => m.Dishes)
               .WithOne(d => d.Menu)
               .HasForeignKey(d => d.MenuId);
    }
}