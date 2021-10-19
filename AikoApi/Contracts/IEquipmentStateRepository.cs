using System;
using System.Collections;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IEquipmentStateRepository : IRepositoryBase<EquipmentState>
    {
        IEnumerable<EquipmentState> GetAll();

        EquipmentState GetById(Guid id);

        EquipmentState GetByName(string name);
        
        EquipmentState GetByColor(string color);
    }
}