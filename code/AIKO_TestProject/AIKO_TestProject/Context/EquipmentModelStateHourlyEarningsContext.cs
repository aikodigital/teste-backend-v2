using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Context
{
    public class EquipmentModelStateHourlyEarningsContext : DbContext
    {
        public DbSet<Models.EquipmentModelStateHourlyEarnings> EquipmentModelStateHourlyEarnings { get; set; }

        public EquipmentModelStateHourlyEarningsContext(DbContextOptions<EquipmentModelStateHourlyEarningsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.EquipmentModelStateHourlyEarnings>()
                .HasKey(nameof(Models.EquipmentModelStateHourlyEarnings.equipment_model_id), nameof(Models.EquipmentModelStateHourlyEarnings.equipment_state_id), nameof(Models.EquipmentModelStateHourlyEarnings.value));
        }
    }
}
