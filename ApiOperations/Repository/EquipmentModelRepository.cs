using ApiOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Repository
{
    public class EquipmentModelRepository : IEquipmentModelRepository
    {
        public IEnumerable<object> GetEquipmentModels()
        {
            var context = new postgresContext();
            var data = context.EquipmentModels.Select(e => new { e.Id, e.Name });
            return data;
        }

        public object GetEquipmentModel(Guid id)
        {
            var context = new postgresContext();
            var data = context.EquipmentModels.Where(e => e.Id == id).FirstOrDefault();
            return new { id = data.Id, name = data.Name };
        }

        public object GetEquipmentModel(string name)
        {
            var context = new postgresContext();
            var data = context.EquipmentModels.Where(e => e.Name == name).FirstOrDefault();
            return new { id = data.Id, name = data.Name };
        }

        public EquipmentModel GetEquipmentModelGuid(Guid id)
        {
            var context = new postgresContext();
            return context.EquipmentModels.Where(e => e.Id == id).FirstOrDefault();
        }

        public bool PostEquipmentModel(EquipmentModel equipmentModel)
        {
            var context = new postgresContext();
            context.EquipmentModels.Add(equipmentModel);
            context.SaveChanges();
            return true;
        }

        public bool DeleteEquipmentModel(Guid id)
        {
            var context = new postgresContext();
            context.EquipmentModels.Remove(GetEquipmentModelGuid(id));
            context.SaveChanges();
            return true;
        }

        public bool PutEquipmentModel(EquipmentModel equipmentModel)
        {
            var context = new postgresContext();
            context.EquipmentModels.Update(equipmentModel);
            context.SaveChanges();
            return true;
        }

    }
}
