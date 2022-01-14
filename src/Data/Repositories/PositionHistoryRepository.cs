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
    public class PositionHistoryRepository : Repository<PositionHistory>, IPositionHistoryRepository
    {
        public PositionHistoryRepository(ApplicationDbContext db) : base(db) { }

        public async Task<IEnumerable<PositionHistory>> GetPositionHistory(Guid id)
        {
            return await Db.PositionHistories.Where(p => p.EquipmentId == id).ToListAsync();
        }

        public async Task<PositionHistory> GetCurrentPosition(Guid id)
        {
            return await Db.PositionHistories
                .Where(p => p.EquipmentId == id)
                .OrderBy(p => p.Date)
                .LastOrDefaultAsync();
        }

        public void RemovePositionHistory(IEnumerable<PositionHistory> positionHistories)
        {
            Db.PositionHistories.RemoveRange(positionHistories);
        }
    }
}