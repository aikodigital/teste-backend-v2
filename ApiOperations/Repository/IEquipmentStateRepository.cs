using ApiOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Repository
{
    public interface IEquipmentStateRepository
    {
        IEnumerable<EquipmentState> GetEquipmentStates();
        EquipmentState GetEquipmentState(Guid id);
        EquipmentState GetEquipmentState(string name);
        bool PostEquipmentState(EquipmentState equipmentState);
        bool DeleteEquipmentState(Guid id);
        bool PutEquipmentState(EquipmentState equipmentState);

    }
}
