using System;
using System.Collections;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IEquipmentModelStateHourlyEarningsRepository : IRepositoryBase<EquipmentModelStateHourlyEarnings>
    {
        EquipmentModelStateHourlyEarnings GetAll();

        EquipmentModelStateHourlyEarnings GetByEquipmentModelId(Guid id);
        
        EquipmentModelStateHourlyEarnings GetByEquipmentStateId(Guid id);

        IEnumerable<EquipmentModelStateHourlyEarnings> GetByValue(float value);
    }
}