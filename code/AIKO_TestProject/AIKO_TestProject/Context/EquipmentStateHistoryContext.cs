using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Context
{
    public class EquipmentStateHistoryContext : DbContext
    {
        public DbSet<Models.EquipmentStateHistory> EquipmentStateHistories { get; set; }

        public EquipmentStateHistoryContext(DbContextOptions<EquipmentStateHistoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.EquipmentStateHistory>()
                .HasKey(nameof(Models.EquipmentStateHistory.equipment_id), nameof(Models.EquipmentStateHistory.date));
        }
    }
}
