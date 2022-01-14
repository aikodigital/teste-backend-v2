using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class PositionHistoryMapping : IEntityTypeConfiguration<PositionHistory>
    {
        public void Configure(EntityTypeBuilder<PositionHistory> builder)
        {
            builder.ToTable("equipment_position_history");
            builder.HasKey(e => new{e.Latitude, e.Longitude, e.Date});
            builder.Property(e => e.Latitude).HasColumnName("lat");
            builder.Property(e => e.Longitude).HasColumnName("lon");
            builder.Property(e => e.Date).HasColumnName("date");
            builder.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            builder
                .HasOne(e => e.Equipment)
                .WithMany(e => e.PositionHistories)
                .HasForeignKey(e => e.EquipmentId);
        }
    }
}