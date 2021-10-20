using Contracts;
using Entities;

namespace Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DatabaseContext _context;

        public IEquipmentRepository _equipment;
        public IEquipmentModelRepository _equipmentModel;
        public IEquipmentModelStateHourlyEarningsRepository _equipmentModelStateHourlyEarnings;
        public IEquipmentPositionHistoryRepository _equipmentPositionHistory;
        public IEquipmentStateRepository _equipmentState;
        public IEquipmentStateHistoryRepository _equipmentStateHistory;

        public RepositoryWrapper(DatabaseContext context) => _context = context;
       
        // Todo: implementar 
        public IEquipmentRepository Equipment => _equipment ??= new EquipmentRepository(_context);
        public IEquipmentModelRepository EquipmentModel => _equipmentModel ??= new EquipmentModelRepository(_context);
        
        // public IEquipmentModelStateHourlyEarningsRepository EquipmentModelStateHourlyEarnings =>
        //     _equipmentModelStateHourlyEarnings ??= new EquipmentModelStateHourlyEarningsRepository(_context);
        //
        // public IEquipmentPositionHistoryRepository EquipmentPositionHistory =>
        //     _equipmentPositionHistory ??= new EquipmentPositionHistoryRepository(_context);
        // public IEquipmentStateRepository EquipmentState { get; }
        // public IEquipmentStateHistoryRepository EquipmentStateHistory { get; }
        
        // ---------------------------------------------------------------------------------------------------------
        
        public IEquipmentModelStateHourlyEarningsRepository EquipmentModelStateHourlyEarnings { get; }
        public IEquipmentPositionHistoryRepository EquipmentPositionHistory { get; }
        public IEquipmentStateRepository EquipmentState { get; }
        public IEquipmentStateHistoryRepository EquipmentStateHistory { get; }
    }
}