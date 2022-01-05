using System;
using System.IO;
using AikoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace AikoAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Equipment> equipment { get; set; }
        
        public DbSet<EquipmentModel> equipment_model { get; set; }
        
        public DbSet<EquipmentPositionHistory> equipment_position_history { get; set; }
        
        public DbSet<EquipmentState> equipment_state { get; set; }

        public DbSet<EquipmentStateHistory> equipment_state_history { get; set; }

        public DbSet<EquipmentHourlyEarnings> equipment_model_state_hourly_earnings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("operation");

            modelBuilder.Entity<EquipmentHourlyEarnings>().HasKey(ehe => new {ehe.EquipmentModelId, ehe.EquipmentStateId});
            
            modelBuilder.Entity<EquipmentPositionHistory>().HasKey(eph => new {eph.EquipmentId, eph.Date});
            
            modelBuilder.Entity<EquipmentStateHistory>().HasKey(esh => new {esh.EquipmentId, esh.Date});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
            
            optionsBuilder
                .UseNpgsql(configuration.GetSection("ConnectionString").Value)
                .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted })
                .EnableSensitiveDataLogging();
        }
    }
}