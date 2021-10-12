using ApiOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Repository
{
    public interface IEquipmentModelRepository
    {
        IEnumerable<object> GetEquipmentModels();
        object GetEquipmentModel(Guid id);
        object GetEquipmentModel(string name);
        bool PostEquipmentModel(EquipmentModel equipmentModel);
        bool DeleteEquipmentModel(Guid id);
        bool PutEquipmentModel(EquipmentModel equipmentModel);
    }
}
