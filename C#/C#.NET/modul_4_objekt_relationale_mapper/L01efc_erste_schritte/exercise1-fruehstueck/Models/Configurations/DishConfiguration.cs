using FruehstuecksrestaurantMore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksrestaurantMore.Data.Configurations;

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

        // 1:N-Beziehung zu PreparationStep
        // Ein Gericht hat viele Zubereitungsschritte.
        builder.HasMany(d => d.PreparationSteps)
            .WithOne(ps => ps.MoreDish); // Die Navigationseigenschaft in PreparationStep

        // M:N-Beziehung zu Ingredient
        // Ein Gericht hat viele Zutaten, eine Zutat kann in vielen Gerichten sein.
        // EF Core erstellt die Zwischentabelle automatisch.
        builder.HasMany(d => d.Ingredients)
            .WithMany(i => i.MoreDishes);
    }
}
    }
}
