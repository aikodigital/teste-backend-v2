using ApiOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Repository
{
    public class EquipmentStateRepository : IEquipmentStateRepository
    {
        public IEnumerable<EquipmentState> GetEquipmentStates()
        {
            var context = new postgresContext();
            return context.EquipmentStates;
        }

        public EquipmentState GetEquipmentState(Guid id)
        {
            var context = new postgresContext();
            var res = context.EquipmentStates.Where(e => e.Id == id).FirstOrDefault();
            return res;
        }

        public EquipmentState GetEquipmentState(string name)
        {
            var context = new postgresContext();
            var res = context.EquipmentStates.Where(e => e.Name == name).FirstOrDefault();
            return res;
        }

        public bool PostEquipmentState(EquipmentState equipmentState)
        {
            var context = new postgresContext();
            context.EquipmentStates.Add(equipmentState);
            context.SaveChanges();
            return true;
        }

        public bool DeleteEquipmentState(Guid id)
        {
            var context = new postgresContext();
            context.EquipmentStates.Remove(GetEquipmentState(id));
            context.SaveChanges();
            return true;
        }

        public bool PutEquipmentState(EquipmentState equipmentState)
        {
            var context = new postgresContext();
            context.EquipmentStates.Update(equipmentState);
            context.SaveChanges();
            return true;
        }
    }
}
