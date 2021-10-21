﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Entities.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("operation")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Entities.Models.Equipment", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("equipment_model_id")
                        .HasColumnType("uuid");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("equipment_model_id");

                    b.ToTable("equipment");
                });

            modelBuilder.Entity("Entities.Models.EquipmentModel", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("equipment_model");
                });

            modelBuilder.Entity("Entities.Models.EquipmentModelStateHourlyEarnings", b =>
                {
                    b.Property<double>("value")
                        .HasColumnType("double precision");

                    b.Property<Guid>("equipment_model_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("equipment_state_id")
                        .HasColumnType("uuid");

                    b.HasKey("value");

                    b.HasIndex("equipment_model_id");

                    b.HasIndex("equipment_state_id");

                    b.ToTable("equipment_model_state_hourly_earnings");
                });

            modelBuilder.Entity("Entities.Models.EquipmentPositionHistory", b =>
                {
                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("equipment_id")
                        .HasColumnType("uuid");

                    b.Property<float>("lat")
                        .HasColumnType("real");

                    b.Property<float>("lon")
                        .HasColumnType("real");

                    b.HasKey("date");

                    b.HasIndex("equipment_id");

                    b.ToTable("equipment_position_history");
                });

            modelBuilder.Entity("Entities.Models.EquipmentState", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("color")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("equipment_state");
                });

            modelBuilder.Entity("Entities.Models.EquipmentStateHistory", b =>
                {
                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("equipment_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("equipment_state_id")
                        .HasColumnType("uuid");

                    b.HasKey("date");

                    b.HasIndex("equipment_id");

                    b.HasIndex("equipment_state_id");

                    b.ToTable("equipment_state_history");
                });

            modelBuilder.Entity("Entities.Models.Equipment", b =>
                {
                    b.HasOne("Entities.Models.EquipmentModel", "equipment_model")
                        .WithMany()
                        .HasForeignKey("equipment_model_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("equipment_model");
                });

            modelBuilder.Entity("Entities.Models.EquipmentModelStateHourlyEarnings", b =>
                {
                    b.HasOne("Entities.Models.EquipmentModel", "equipmentModel")
                        .WithMany()
                        .HasForeignKey("equipment_model_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.EquipmentState", "equipmentState")
                        .WithMany()
                        .HasForeignKey("equipment_state_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("equipmentModel");

                    b.Navigation("equipmentState");
                });

            modelBuilder.Entity("Entities.Models.EquipmentPositionHistory", b =>
                {
                    b.HasOne("Entities.Models.Equipment", "equipment")
                        .WithMany()
                        .HasForeignKey("equipment_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("equipment");
                });

            modelBuilder.Entity("Entities.Models.EquipmentStateHistory", b =>
                {
                    b.HasOne("Entities.Models.Equipment", "equipment")
                        .WithMany()
                        .HasForeignKey("equipment_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.EquipmentState", "equipmentState")
                        .WithMany()
                        .HasForeignKey("equipment_state_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("equipment");

                    b.Navigation("equipmentState");
                });
#pragma warning restore 612, 618
        }
    }
}
