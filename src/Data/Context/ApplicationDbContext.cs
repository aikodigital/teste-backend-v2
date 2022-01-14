using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<PositionHistory> PositionHistories { get; set; }
        public DbSet<StateHistory> StateHistories { get; set; }
        public DbSet<ModelStateHourlyEarnings> ModelStateHourlyEarnings { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("operation");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}