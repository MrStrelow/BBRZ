using Beziehungen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beziehungen.Data.Configurations;

public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.HasKey(v => v.Id);

        // 1:1-Beziehung zu Table (ein Besuch findet an einem Tisch statt)
        builder.HasOne(v => v.TableUsedDuringVisit)
            .WithMany() // Angenommen, ein Tisch kann mehrere Besuche haben
            .IsRequired();

        // 1:N-Beziehung zu Dish (bei einem Besuch können mehrere Gerichte bestellt werden)
        builder.HasMany(v => v.Dishes)
            .WithOne(); // Einfachste Form für eine 1:N ohne explizite Navigation zurück
    }
}