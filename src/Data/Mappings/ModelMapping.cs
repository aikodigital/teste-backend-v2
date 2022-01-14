using Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ModelMapping : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("equipment_model");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Name).HasColumnName("name");
        }
    }
}