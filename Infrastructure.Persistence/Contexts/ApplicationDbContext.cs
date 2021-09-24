using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, 
            IDateTimeService dateTime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
        }


        public DbSet<NotaUtilizador> Notas { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Equipment_Model> Equipment_Models { get; set; }
        public DbSet<Equipment_model_state_hourly_earnings> Equipment_model_state_hourly_earnings { get; set; }
        public DbSet<Equipment_position_history> Equipment_position_historys { get; set; }
        public DbSet<Equipment_State> Equipment_States { get; set; }
        public DbSet<Equipment_state_history> Equipment_state_historys { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //All Decimals will have 18,6 Range
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }

            builder.Entity<Equipment_State>().HasData(
                    new Equipment_State { id=1, name = "Operando" },
                    new Equipment_State { id = 2, name = "Parado" },
                    new Equipment_State { id = 3, name = "Manutenção" }
                );

            base.OnModelCreating(builder);
        }
    }
}
