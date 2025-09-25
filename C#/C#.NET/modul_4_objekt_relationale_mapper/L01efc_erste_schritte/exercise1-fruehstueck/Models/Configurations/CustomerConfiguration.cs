using FruehstuecksrestaurantMore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksrestaurantMore.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(150);

        // 1:N-Beziehung zu Visit (ein Kunde kann viele Besuche haben)
        builder.HasMany(c => c.visits)
            .WithOne() // Ein Besuch gehört zu einem Kunden
            .IsRequired();
    }
}