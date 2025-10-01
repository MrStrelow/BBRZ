using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksBestellungMVC.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        // muss angegeben werden, und ist automatisch aktuelle datum.
        builder.Property(o => o.OrderTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        // 1-n zu Visit
        // bereits in visit configuriert

        // n-m zu Order
        builder.HasMany(o => o.Dishes)
           .WithMany(d => d.Orders);

        // n-m zu Dish
        builder.HasMany(o => o.Dishes)
            .WithMany(d => d.Orders);
    }
}