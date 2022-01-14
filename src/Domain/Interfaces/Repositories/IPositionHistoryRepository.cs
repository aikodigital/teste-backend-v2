using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IPositionHistoryRepository : IRepository<PositionHistory>
    {
        Task<IEnumerable<PositionHistory>> GetPositionHistory(Guid id);
        Task<PositionHistory> GetCurrentPosition(Guid id);
        void RemovePositionHistory(IEnumerable<PositionHistory> positionHistories);
    }
}