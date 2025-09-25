using FruehstuecksrestaurantMore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksrestaurantMore.Data.Configurations;

public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.HasKey(v => v.Id);

        // 1:1-Beziehung zu Table (ein Besuch findet an einem Tisch statt)
        builder.HasOne(v => v.table)
            .WithMany() // Angenommen, ein Tisch kann mehrere Besuche haben
            .IsRequired();

        // M:N-Beziehung zu Dish (bei einem Besuch können mehrere Gerichte bestellt werden)
        builder.HasMany(v => v.dishes)
            .WithMany(); // Einfachste Form für eine M:N ohne explizite Navigation zurück
    }
}