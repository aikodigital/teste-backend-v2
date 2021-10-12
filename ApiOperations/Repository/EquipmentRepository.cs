using ApiOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        public object GetEquipment(Guid id)
        {
            var context = new postgresContext();
            var res = context.Equipment.Where(e => e.Id == id).FirstOrDefault();
            var equipModel = GetEquipModelName(res.EquipmentModelId);
            return new { id = res.Id, equipmentModelId = equipModel, name = res.Name };
        }
        public object GetEquipment(string name)
        {
            var context = new postgresContext();
            var res = context.Equipment.Where(e => e.Name == name).FirstOrDefault();
            var equipModel = GetEquipModelName(res.EquipmentModelId);
            return new { id = res.Id, equipmentModelId = equipModel, name = res.Name }; ;
        }
        public Equipment GetEquipmentGuid(Guid id)
        {
            var context = new postgresContext();
            var res = context.Equipment.Where(e => e.Id == id).FirstOrDefault();
            return res;
        }
        public IEnumerable<object> GetEquipments()
        {
            var context = new postgresContext();
            var res = context.Equipment.Join(context.EquipmentModels, equip => equip.EquipmentModelId, model => model.Id, (equip, model) => new
            {
                equip.Id,
                equip.Name,
                EquipmentModel = model.Name
            });
            return res;
        }
        public IEnumerable<ViewsObj.ViewEquipment.Equipment> GetEquipmentsView()
        {
            var context = new postgresContext();
            var res = context.Equipment.Join(context.EquipmentModels, equip => equip.EquipmentModelId, model => model.Id, (equip, model) => new
            {
                equip.Id,
                equip.Name,
                EquipmentModel = model.Name
            });
            List<ViewsObj.ViewEquipment.Equipment> list = new();
            foreach (var item in res)
            {
                list.Add(new ViewsObj.ViewEquipment.Equipment()
                {
                    Model = item.EquipmentModel,
                    Name = item.Name
                });
            }
            return list;
        }
        public bool PostEquipment(Equipment equipment)
        {
            var context = new postgresContext();
            context.Equipment.Add(equipment);
            context.SaveChanges();
            return true;
        }
        public bool DeleteEquipment(Guid id)
        {
            var context = new postgresContext();
            context.Equipment.Remove(GetEquipmentGuid(id));
            context.SaveChanges();
            return true;
        }
        public bool PutEquipment(Equipment equipment)
        {
            var context = new postgresContext();
            context.Equipment.Update(equipment);
            context.SaveChanges();
            return true;
        }
        private static string GetEquipModelName(Guid id)
        {
            var context = new postgresContext();
            return context.EquipmentModels.Where(m => m.Id == id).FirstOrDefault().Name;
        }
    }
}
