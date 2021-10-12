using ApiOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Repository
{
    public interface IEquipmentRepository
    {
        IEnumerable<object> GetEquipments();
        IEnumerable<ViewsObj.ViewEquipment.Equipment> GetEquipmentsView();
        object GetEquipment(Guid id);
        object GetEquipment(string name);
        Equipment GetEquipmentGuid(Guid id);
        bool PostEquipment(Equipment equipment);
        bool PutEquipment(Equipment equipment);
        bool DeleteEquipment(Guid id);
    }
}
