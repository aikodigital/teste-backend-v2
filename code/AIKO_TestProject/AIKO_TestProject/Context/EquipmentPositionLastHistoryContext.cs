using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Context
{
    public class EquipmentPositionLastHistoryContext : DbContext
    {
        public DbSet<Models.EquipmentPositionLastHistory> EquipmentPositionLastHistories { get; set; }

        public EquipmentPositionLastHistoryContext(DbContextOptions<EquipmentPositionLastHistoryContext> options) :
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.EquipmentPositionLastHistory>()
                .HasKey(nameof(Models.EquipmentPositionLastHistory.equipment_id), nameof(Models.EquipmentPositionLastHistory.date));
        }
    }
}
