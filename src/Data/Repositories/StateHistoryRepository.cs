using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Data.Context;

using Domain.Interfaces.Repositories;
using Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class StateHistoryRepository : Repository<StateHistory>, IStateHistoryRepository
    {
        public StateHistoryRepository(ApplicationDbContext db) : base(db) { }
        
        public async Task<IEnumerable<StateHistory>> GetStateHistory(Guid id)
        {
            return await Db.StateHistories
                .Where(s => s.EquipmentId == id)
                .OrderBy(s => s.Date)
                .ToListAsync();
        }

        public async Task<StateHistory> GetCurrentState(Guid id)
        {
            return await Db.StateHistories
                .Where(p => p.EquipmentId == id)
                .OrderBy(p => p.Date)
                .LastOrDefaultAsync();
        }
        
        public void RemoveStateHistory(IEnumerable<StateHistory> stateHistories)
        {
            Db.StateHistories.RemoveRange(stateHistories);
        }
    }
}