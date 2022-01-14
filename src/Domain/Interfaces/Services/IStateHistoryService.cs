using System;

using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IStateHistoryService
    {
        bool Create(StateHistory stateHistory);
        bool DeleteStateHistory(Guid id);
    }
}