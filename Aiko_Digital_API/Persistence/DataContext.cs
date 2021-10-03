﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentModel> EquipmentModels { get; set; }
        public virtual DbSet<EquipmentModelStateHourlyEarning> EquipmentModelStateHourlyEarnings { get; set; }
        public virtual DbSet<EquipmentPositionHistory> EquipmentPositionHistories { get; set; }
        public virtual DbSet<EquipmentState> EquipmentStates { get; set; }
        public virtual DbSet<EquipmentStateHistory> EquipmentStateHistories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF8");

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.ToTable("equipment", "operation");

                entity.Property(e => e.Id)
                    // .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.EquipmentModelId).HasColumnName("equipment_model_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                // entity.HasOne(d => d.EquipmentModel)
                //     .WithMany(p => p.Equipment)
                //     .HasForeignKey(d => d.EquipmentModelId)
                //     .OnDelete(DeleteBehavior.ClientSetNull)
                //     .HasConstraintName("fk_equipment_model");
            });

            modelBuilder.Entity<EquipmentModel>(entity =>
            {
                entity.ToTable("equipment_model", "operation");

                entity.Property(e => e.Id)
                    // .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<EquipmentModelStateHourlyEarning>(entity =>
            {
                // entity.HasNoKey();
                entity.HasKey(c => new {c.EquipmentModelId, c.EquipmentStateId});

                entity.ToTable("equipment_model_state_hourly_earnings", "operation");

                entity.Property(e => e.EquipmentModelId).HasColumnName("equipment_model_id");

                entity.Property(e => e.EquipmentStateId).HasColumnName("equipment_state_id");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.EquipmentModel)
                    .WithMany()
                    .HasForeignKey(d => d.EquipmentModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_equipment_model");

                entity.HasOne(d => d.EquipmentState)
                    .WithMany()
                    .HasForeignKey(d => d.EquipmentStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_equipment_state");
            });

            modelBuilder.Entity<EquipmentPositionHistory>(entity =>
            {
                //entity.HasNoKey();
                entity.HasKey(e => e.EquipmentId);
                
                entity.ToTable("equipment_position_history", "operation");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lon).HasColumnName("lon");

                entity.HasOne(d => d.Equipment)
                    .WithMany()
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_equipment");
            });

            modelBuilder.Entity<EquipmentState>(entity =>
            {
                entity.ToTable("equipment_state", "operation");

                entity.Property(e => e.Id)
                    // .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<EquipmentStateHistory>(entity =>
            {
                //entity.HasNoKey();
                entity.HasKey(e => new {e.EquipmentId, e.EquipmentStateId});
                
                entity.ToTable("equipment_state_history", "operation");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

                entity.Property(e => e.EquipmentStateId).HasColumnName("equipment_state_id");

                entity.HasOne(d => d.Equipment)
                    .WithMany()
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_equipment");

                entity.HasOne(d => d.EquipmentState)
                    .WithMany()
                    .HasForeignKey(d => d.EquipmentStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_equipment_state");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        // }
    }
}