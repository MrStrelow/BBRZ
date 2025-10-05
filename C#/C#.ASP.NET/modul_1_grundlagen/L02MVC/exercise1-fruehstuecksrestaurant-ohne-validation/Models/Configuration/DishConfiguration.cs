using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksBestellungMVC.Data.Configurations;

public class DishConfiguration : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name).IsRequired().HasMaxLength(150);

        builder.Property(d => d.Price)
               .HasColumnType("decimal(4,2)");

        // n-m zu Ingredient
        builder.HasMany(d => d.Ingredients)
               .WithMany(i => i.Dishes);

        // n-m zu PreperationStep
        builder.HasMany(d => d.PreparationSteps)
               .WithMany(ps => ps.Dishes);

        // n-m zu Dishes
        // Wird in Menu configuriert.

        // n-m zu Order
        // Wird in Order configuriert.
    }
}