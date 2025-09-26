using Beziehungen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beziehungen.Data.Configurations;

public class PreparationStepConfiguration : IEntityTypeConfiguration<PreparationStep>
{
    public void Configure(EntityTypeBuilder<PreparationStep> builder)
    {
        builder.HasKey(ps => ps.Id);

        builder.Property(ps => ps.Instruction)
            .IsRequired();

        // Hier wird die Beziehung zum "Parent" (Dish) konfiguriert.
        // EF Core wird automatisch eine Shadow Property als Fremdschlüssel (`MoreDishId`)
        // erstellen, da wir keine explizite FK-Property im Modell haben.
        builder.HasMany(ps => ps.Dishes)
            .WithMany(d => d.PreparationSteps);
    }
}