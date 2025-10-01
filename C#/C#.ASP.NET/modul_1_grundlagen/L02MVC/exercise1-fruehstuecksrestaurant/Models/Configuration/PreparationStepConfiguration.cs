using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruehstuecksBestellungMVC.Data.Configurations;

public class PreparationStepConfiguration : IEntityTypeConfiguration<PreparationStep>
{
    public void Configure(EntityTypeBuilder<PreparationStep> builder)
    {
        builder.HasKey(p => p.PreparationStepId);
        builder.Property(p => p.Description).IsRequired();
    }
}