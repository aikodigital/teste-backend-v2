using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("operation");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<EquipmentModel> EquipmentModels { get; set; }

        public DbSet<EquipmentModelStateHourlyEarnings> EquipmentModelStateHourlyEarnings { get; set; }

        public DbSet<EquipmentPositionHistory> EquipmentPositionHistories { get; set; }

        public DbSet<EquipmentState> EquipmentStates { get; set; }

        public DbSet<EquipmentStateHistory> EquipmentStateHistories { get; set; }
    }
}