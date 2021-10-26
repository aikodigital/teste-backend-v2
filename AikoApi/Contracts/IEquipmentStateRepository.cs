using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IEquipmentStateRepository : IRepositoryBase<EquipmentState>
    {
        Task<List<EquipmentState>> GetAll();

        Task<EquipmentState> GetById(Guid id);

        Task<List<EquipmentState>> GetByName(string name);
        
        Task<List<EquipmentState>> GetByColor(string color);
        
        Task<EquipmentState> Post(EquipmentState model);

        Task<EquipmentState> Put(EquipmentState model);

        Task<bool> Remove(EquipmentState model);
    }
}