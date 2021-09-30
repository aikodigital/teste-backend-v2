using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Context
{
    public class EquipmentModelContext : DbContext
    {
        public DbSet<Models.EquipmentModel> EquipmentModels { get; set; }

        public EquipmentModelContext(DbContextOptions<EquipmentModelContext> options) : base(options)
        {
        }
    }
}
