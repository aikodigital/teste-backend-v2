using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Context
{
    public class EquipmentPositionHistoryContext : DbContext
    {
        public DbSet<Models.EquipmentPositionHistory> EquipmentPositionHistories { get; set; }

        public EquipmentPositionHistoryContext(DbContextOptions<EquipmentPositionHistoryContext> options) :
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.EquipmentPositionHistory>()
                .HasKey(nameof(Models.EquipmentPositionHistory.equipment_id), nameof(Models.EquipmentPositionHistory.date));
        }
    }
}
