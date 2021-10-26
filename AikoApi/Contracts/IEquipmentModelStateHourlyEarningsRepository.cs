using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IEquipmentModelStateHourlyEarningsRepository : IRepositoryBase<EquipmentModelStateHourlyEarnings>
    {
        Task<List<EquipmentModelStateHourlyEarnings>> GetAll();

        Task<List<EquipmentModelStateHourlyEarnings>> GetByEquipmentModelId(Guid id);
        
        Task<List<EquipmentModelStateHourlyEarnings>> GetByEquipmentStateId(Guid id);

        Task<List<EquipmentModelStateHourlyEarnings>> GetByValue(float value);
        
        Task<EquipmentModelStateHourlyEarnings> Post(EquipmentModelStateHourlyEarnings model);

        Task<EquipmentModelStateHourlyEarnings> Put(EquipmentModelStateHourlyEarnings model);

        Task<bool> Remove(EquipmentModelStateHourlyEarnings model);
    }
}