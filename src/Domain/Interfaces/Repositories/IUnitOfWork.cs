using System;

namespace Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEquipmentRepository EquipmentRepository { get; }
        IModelRepository ModelRepository { get; }
        IStateRepository StateRepository { get; }
        IPositionHistoryRepository PositionHistoryRepository { get; }
        IStateHistoryRepository StateHistoryRepository { get; }
        IModelStateHourlyEarningsRepository ModelStateHourlyEarningsRepository { get; }
        bool Commit();
    }
}