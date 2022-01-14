using Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class StateHistoryMapping : IEntityTypeConfiguration<StateHistory>
    {
        public void Configure(EntityTypeBuilder<StateHistory> builder)
        {
            builder.ToTable("equipment_state_history");
            builder.HasKey(e => new {e.StateId, e.EquipmentId});
            builder.Property(e => e.Date).HasColumnName("date");
            builder.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            builder.Property(e => e.StateId).HasColumnName("equipment_state_id");
            builder
                .HasOne(e => e.Equipment)
                .WithMany(e => e.StateHistories)
                .HasForeignKey(e => e.EquipmentId);
            builder
                .HasOne(e => e.State)
                .WithMany(e => e.StateHistories)
                .HasForeignKey(e => e.StateId);
            builder.Navigation(e => e.Equipment).AutoInclude();
            builder.Navigation(e => e.State).AutoInclude();
        }
    }
}