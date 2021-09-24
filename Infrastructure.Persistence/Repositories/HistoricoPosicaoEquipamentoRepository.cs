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
    public class HistoricoPosicaoEquipamentoRepository : 
        GenericRepositoryAsync<Equipment_position_history>,
        IHistoricoPosicaoEquipamentoRepository
    {
        private readonly DbSet<Equipment_position_history> equipment;

        public HistoricoPosicaoEquipamentoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            equipment = dbContext.Set<Equipment_position_history>();
        }

        public async Task<Equipment_position_history> GetPosicaoAtualById(Guid id)
        {
            return await equipment
                .AsNoTracking()
                .Where(x => x.equipment_id == id)
                .OrderByDescending(x => x.date)
                .FirstAsync();
        }
    }
}
