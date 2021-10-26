namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IEquipmentRepository Equipment { get; } 
        
        IEquipmentModelRepository EquipmentModel { get; } 
        
        IEquipmentModelStateHourlyEarningsRepository EquipmentModelStateHourlyEarnings { get; }
        
        IEquipmentPositionHistoryRepository EquipmentPositionHistory { get; }
        
        IEquipmentStateRepository EquipmentState { get; }
        
        IEquipmentStateHistoryRepository EquipmentStateHistory { get; }
    }
}