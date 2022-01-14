using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IStateHistoryRepository : IRepository<StateHistory>
    {
        Task<IEnumerable<StateHistory>> GetStateHistory(Guid id);
        Task<StateHistory> GetCurrentState(Guid id);
        void RemoveStateHistory(IEnumerable<StateHistory> stateHistories);
    }
}