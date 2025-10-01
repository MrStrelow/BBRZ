using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksBestellungMVC.Data.Configurations;

public class DishConfiguration : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.HasKey(d => d.DishId);

        builder.Property(d => d.Name).IsRequired().HasMaxLength(150);

        builder.Property(d => d.Price)
               .HasColumnType("decimal(18,2)");

        builder.HasMany(d => d.Ingredients)
               .WithOne(i => i.Dish);

        builder.HasMany(d => d.PreparationSteps)
               .WithMany(p => p.Dishes);
    }
}