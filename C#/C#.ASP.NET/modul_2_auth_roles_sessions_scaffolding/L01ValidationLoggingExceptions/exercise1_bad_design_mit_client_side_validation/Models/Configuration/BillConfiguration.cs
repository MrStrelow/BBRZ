using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksBestellungMVC.Models.Configuration;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.TotalAmount).IsRequired().HasColumnType("decimal(10,2)");
        
        // muss angegeben werden, und ist automatisch aktuelle datum.
        builder.Property(b => b.BillDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();
    }
}
