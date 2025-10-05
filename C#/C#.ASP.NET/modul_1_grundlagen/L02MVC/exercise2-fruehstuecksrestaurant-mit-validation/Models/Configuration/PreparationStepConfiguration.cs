using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksBestellungMVC.Data.Configurations;

public class PreparationStepConfiguration : IEntityTypeConfiguration<PreparationStep>
{
    public void Configure(EntityTypeBuilder<PreparationStep> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.StepOrder).HasColumnType("tinyint").IsRequired(); // 256 zustände
     }
}