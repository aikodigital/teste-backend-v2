using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Context
{
    public class EquipmentStateContext : DbContext
    {
        public DbSet<Models.EquipmentState> EquipmentStates { get; set; }

        public EquipmentStateContext(DbContextOptions<EquipmentStateContext> options) : base(options)
        {
        }
    }
}
