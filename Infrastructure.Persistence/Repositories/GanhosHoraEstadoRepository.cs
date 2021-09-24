using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class GanhosHoraEstadoRepository : 
        GenericRepositoryAsync<Equipment_model_state_hourly_earnings>,
        IGanhosHoraEstadoRepository
    {
        private readonly DbSet<Equipment_model_state_hourly_earnings> equipment_model_state_hourly_earnings;

        public GanhosHoraEstadoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            equipment_model_state_hourly_earnings = dbContext.Set<Equipment_model_state_hourly_earnings>();
        }

        public async Task<int> GetQuantHorasOperando(Guid id)
        {
            var dado = await equipment_model_state_hourly_earnings
                .AsNoTracking()
                .Where(x => x.equipment_model_id == id 
                && (Estados)x.equipment_state_id == Estados.OPERANDO)
                .FirstOrDefaultAsync();
            return dado != null ? (int)dado.value : 0;
        }

        public async Task<int> GetQuantHorasManutencao(Guid id)
        {
            var dado = await equipment_model_state_hourly_earnings
                .AsNoTracking()
                .Where(x => x.equipment_model_id == id
                && (Estados)x.equipment_state_id == Estados.MANUTENCAO)
                .FirstOrDefaultAsync();
            return dado != null ? (int)dado.value : 0;
        }
    }
}
