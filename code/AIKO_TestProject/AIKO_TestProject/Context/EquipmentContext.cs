using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Context
{
    public class EquipmentContext : DbContext
    {
        public DbSet<Models.Equipment> Equipments { get; set; }

        public EquipmentContext(DbContextOptions<EquipmentContext> options) : base(options)
        {
        }
    }
}
