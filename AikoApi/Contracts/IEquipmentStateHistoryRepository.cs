using System;
using System.Collections;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IEquipmentStateHistoryRepository : IRepositoryBase<IEquipmentStateHistoryRepository>
    {
        IEnumerable<EquipmentStateHistory> GetAll();

        EquipmentStateHistory GetByEquipmentId(Guid id);
        
        EquipmentStateHistory GetByEquipmentStateId(Guid id);
        
        IEnumerable<EquipmentStateHistory> GetByDate(Guid id);
        
    }
}