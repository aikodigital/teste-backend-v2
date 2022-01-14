using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class EquipmentMapping : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("equipment");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.ModelId).HasColumnName("equipment_model_id");
            builder
                .HasOne(e => e.Model)
                .WithMany(e => e.Equipments)
                .HasForeignKey(e => e.ModelId);
            builder.Navigation(e => e.Model).AutoInclude();
        }
    }
}