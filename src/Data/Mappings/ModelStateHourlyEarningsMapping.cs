using Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ModelStateHourlyEarningsMapping : IEntityTypeConfiguration<ModelStateHourlyEarnings>
    {
        public void Configure(EntityTypeBuilder<ModelStateHourlyEarnings> builder)
        {
            builder.ToTable("equipment_model_state_hourly_earnings");
            builder.HasKey(e => new {e.StateId, e.ModelId});
            builder.Property(e => e.Value).HasColumnName("value");
            builder.Property(e => e.ModelId).HasColumnName("equipment_model_id");
            builder.Property(e => e.StateId).HasColumnName("equipment_state_id");
            builder
                .HasOne(e => e.State)
                .WithMany(e => e.ModelStateHourlyEarnings)
                .HasForeignKey(e => e.StateId);
            builder
                .HasOne(e => e.Model)
                .WithMany(e => e.ModelStateHourlyEarnings)
                .HasForeignKey(e => e.ModelId);
            builder.Navigation(e => e.State).AutoInclude();
            builder.Navigation(e => e.Model).AutoInclude();
        }
    }
}