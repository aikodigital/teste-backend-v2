using System;
using System.Threading.Tasks;

using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IPositionHistoryService
    {
        bool Create(PositionHistory positionHistory);
        bool DeletePositionHistory(Guid id);
    }
}