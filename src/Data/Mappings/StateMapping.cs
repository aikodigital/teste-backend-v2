using Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class StateMapping : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("equipment_state");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Color).HasColumnName("color");
        }
    }
}