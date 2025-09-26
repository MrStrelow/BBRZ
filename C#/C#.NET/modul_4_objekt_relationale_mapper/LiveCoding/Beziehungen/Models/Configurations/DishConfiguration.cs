using Beziehungen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beziehungen.Data.Configurations;

public class DishConfiguration : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Description)
            .HasMaxLength(500);

        builder.Property(d => d.Price)
            .HasColumnType("decimal(18,2)");

        // N:M-Beziehung zu PreparationStep
        builder.HasMany(d => d.PreparationSteps)
            .WithMany(ps => ps.Dishes);

        // 1:N-Beziehung zu Ingredient
        builder.HasMany(d => d.Ingredients)
            .WithOne(i => i.Dishes);
    }
}