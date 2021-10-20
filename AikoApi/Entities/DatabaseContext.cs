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
        //Todo: adicionar entidades
        public DbSet<EquipmentModel> EquipmentModels { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

    }
}