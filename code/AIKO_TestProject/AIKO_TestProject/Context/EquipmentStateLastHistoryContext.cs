using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Context
{
    public class EquipmentStateLastHistoryContext : DbContext
    {
        public DbSet<Models.EquipmentStateLastHistory> EquipmentStateLastHistories { get; set; }

        public EquipmentStateLastHistoryContext(DbContextOptions<EquipmentStateLastHistoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.EquipmentStateLastHistory>()
                .HasKey(nameof(Models.EquipmentStateLastHistory.equipment_id), nameof(Models.EquipmentStateLastHistory.date));
        }
    }
}
