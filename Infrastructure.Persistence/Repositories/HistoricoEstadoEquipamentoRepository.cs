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
    public class HistoricoEstadoEquipamentoRepository :
        GenericRepositoryAsync<Equipment_state_history>,
        IHistoricoEstadoEquipamentoRepository
    {
        private readonly DbSet<Equipment_state_history> _dbContext;

        public HistoricoEstadoEquipamentoRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext.Set<Equipment_state_history>();
        }

        public async Task<Equipment_state_history> GetEstadoAtualById(Guid id)
        {
            return await _dbContext
                .AsNoTracking()
                .Where(x => x.equipment_id == id)
                .OrderByDescending(x => x.date)
                .FirstAsync();
        }

        public async Task<int> GetQuantHorasOperando(Guid id)
        {
            return _dbContext
                .AsNoTracking()
                .Where(x => x.equipment_id == id && (Estados)x.equipment_state_id == Estados.OPERANDO)
                .OrderByDescending(x => x.date)
                .Count();
        }

        public async Task<int> GetQuantHorasManutencao(Guid id)
        {
            return _dbContext
                .AsNoTracking()
                .Where(x => x.equipment_id == id && (Estados)x.equipment_state_id == Estados.OPERANDO)
                .OrderByDescending(x => x.date)
                .Count();
        }

        public async Task<int> GetQuantHorasOperandoHoje(Guid id)
        {
            var hoje = DateTime.Now;

            return _dbContext
                .AsNoTracking()
                .Where(x => 
                (x.equipment_id == id)
                && ((Estados)x.equipment_state_id == Estados.OPERANDO)
                && (x.date.Year==hoje.Year && x.date.Month==hoje.Month && x.date.Day==hoje.Day)
                )
                .OrderByDescending(x => x.date)
                .Count();
        }

        public async Task<int> GetQuantHorasHoje(Guid id)
        {
            var hoje = DateTime.Now;

            return _dbContext
                .AsNoTracking()
                .Where(x => x.equipment_id == id
                && (x.date.Year == hoje.Year && x.date.Month == hoje.Month && x.date.Day == hoje.Day)
                )
                .OrderByDescending(x => x.date)
                .Count();
        }
    }
}
