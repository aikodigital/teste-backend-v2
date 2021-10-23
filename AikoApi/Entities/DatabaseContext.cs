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

            // modelBuilder
            //     .Entity<EquipmentState>()
            //     .HasMany(x => x.equipments)
            //     .WithMany(x => x.equipmentStates)
            //     .UsingEntity<EquipmentStateHistory>(
            //         x => x
            //             .HasOne(x => x.equipment)
            //             .WithMany(x => x.EquipmentStatesHistories)
            //             .HasForeignKey(x => x.equipment_id),
            //         x => x
            //             .HasOne(x => x.equipment_state)
            //             .WithMany(x => x.equipmentStateHistories)
            //             .HasForeignKey(x => x.equipment_state),
            //         x =>
            //         {
            //             x.HasKey(x =>
            //                 new
            //                 {
            //                     x.equipment_id,
            //                     x.equipment_state_id
            //                 });
            //         });
            //
            // modelBuilder
            //     .Entity<EquipmentState>()
            //     .HasMany(x => x.equipmentsModels)
            //     .WithMany(x => x.equipmentStates)
            //     .UsingEntity<EquipmentModelStateHourlyEarnings>(
            //         x => x
            //             .HasOne(x => x.equipment_model)
            //             .WithMany(x => x)
            //             .HasForeignKey(x => x.equipment_model_id),
            //         x => x
            //             .HasOne(x => x.equipment_state)
            //             .WithMany(x => x.equipmentModelStateHourlyEarnings)
            //             .HasForeignKey(x => x.equipment_state_id),
            //         x =>
            //         {
            //             x.HasKey(x =>
            //                 new
            //                 {
            //                     x.equipment_state_id,
            //                     x.equipment_model_id
            //                 });
            //         });
            // modelBuilder.Entity<EquipmentStateHistory>().HasIndex(x => x.equipment_state);
            // modelBuilder.Entity<EquipmentModelStateHourlyEarnings>().HasIndex(x => x.equipment_model);
            // modelBuilder.Entity<EquipmentStateHistory>().HasKey(x => new {x.equipment_id, x.equipment});
            // modelBuilder.Entity<EquipmentStateHistory>().HasKey(x => new {x.equipment_state_id, x.equipment_state});
            // modelBuilder.Entity<EquipmentModelStateHourlyEarnings>()
            //     .HasKey(x => new {x.equipment_model_id, x.equipment_model});
            // modelBuilder.Entity<EquipmentModelStateHourlyEarnings>()
            //     .HasKey(x => new {x.equipment_state_id, x.equipment_state});


            // modelBuilder
            // .Entity<EquipmentState>()
            // .HasMany(p => p.equipments)
            // .WithMany(p => p.equipmentStates)
            // .UsingEntity(j => j.ToTable("equipment_state_history"));
            //
            // modelBuilder
            //     .Entity<EquipmentState>()
            //     .HasMany(p => p.equipmentsModels)
            //     .WithMany(p => p.equipmentStates)
            //     .UsingEntity(j => j.ToTable("equipment_state_hourly_earnings"));
            //
            // modelBuilder.Entity<EquipmentState>()
            //     .HasMany<Equipment>(s => s.equipments)
            //     .WithMany(c => c.equipmentStates)
            //     .UsingEntity<EquipmentStateHistory>(
            //         x => x
            //             .HasOne(x => x.equipment)
            //             .WithMany(x => x.equipmentStateHistories)
            //             .HasForeignKey(x => x.equipment_id),
            //         x => x
            //             .HasOne(x => x.equipmentState)
            //             .WithMany(x => x.equipmentStateHistories)
            //             .HasForeignKey(x => x.equipment_state_id),
            //         x =>
            //         {
            //             x.HasKey(x => new
            //             {
            //                 x.equipment_state_id,
            //                 x.equipment_id
            //             });
            //         });
            // modelBuilder.Entity<EquipmentModelStateHourlyEarnings>().HasNoKey();
            // modelBuilder.Entity<EquipmentStateHistory>().HasNoKey();
            // .HasAlternateKey(x => x.id);
            // .WithMany(c => c.Books)
            // .Map(cs =>
            // {
            // cs.MapLeftKey("BookId");
            // cs.MapRightKey("CategoryId");
            // cs.ToTable("BookCategories");
            // });
            // Map(cs =>
            // {
            // cs.MapLeftKey("StudentRefId");
            // cs.MapRightKey("CourseRefId");
            // cs.ToTable("StudentCourse");
            // });
        }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<EquipmentModel> EquipmentModels { get; set; }

        public DbSet<EquipmentModelStateHourlyEarnings> EquipmentModelStateHourlyEarnings { get; set; }

        public DbSet<EquipmentPositionHistory> EquipmentPositionHistories { get; set; }

        public DbSet<EquipmentState> EquipmentStates { get; set; }

        public DbSet<EquipmentStateHistory> EquipmentStateHistories { get; set; }
    }
}