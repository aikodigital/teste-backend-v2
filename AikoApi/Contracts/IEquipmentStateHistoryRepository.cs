using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IEquipmentStateHistoryRepository : IRepositoryBase<EquipmentStateHistory>
    {
        Task<List<EquipmentStateHistory>> GetAll();

        Task<List<EquipmentStateHistory>> GetByEquipmentId(Guid id);
        
        Task<List<EquipmentStateHistory>> GetByEquipmentStateId(Guid id);
        
        Task<List<EquipmentStateHistory>> GetByDate(DateTime dateTime);
        
        Task<EquipmentStateHistory> Post(EquipmentStateHistory model);

        Task<EquipmentStateHistory> Put(EquipmentStateHistory model);
        
        Task<bool> Remove(EquipmentStateHistory model);
    }
}