using Contracts;
using Entities;

namespace Repositories
{
    public class RepositoryWrapper
    {
        private readonly DatabaseContext _context;

        public IEquipmentRepository _equipment;
        public IEquipmentModelRepository _equipmentModel;
        public IEquipmentModelStateHourlyEarningsRepository _EquipmentModelStateHourlyEarnings;
        public IEquipmentPositionHistoryRepository _equipmentPositionHistory;
        public IEquipmentStateRepository _equipmentState;
        public IEquipmentStateHistoryRepository _equipmentStateHistory;

        public RepositoryWrapper(DatabaseContext context) => _context = context;
       
        // Todo: implementar 
        public IEquipmentRepository Equipment => _equipment ??= new EquipmentRepository(_context);
    }
}