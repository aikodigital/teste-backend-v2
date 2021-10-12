using ApiOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Repository
{
    public class StateHistoryRepository : IStateHistoryRepository
    {
        public object GetLastState(Guid id)
        {
            var context = new postgresContext();
            var res = context.EquipmentStateHistories.Where(e => e.EquipmentId == id).OrderByDescending(e=>e.Date).First();
            return new { equipment = GetNameEquipment(id), date = res.Date, state = GetNameState(res.EquipmentStateId) };
        }

        public IEnumerable<object> GetStateHistories(Guid id)
        {
            var context = new postgresContext();
            var res = context.EquipmentStateHistories.Where(e => e.EquipmentId == id).OrderBy(e => e.Date);
            var equipment = GetNameEquipment(id);
            List<object> list = new();
            foreach (var item in res)
            {
                list.Add(new
                {
                    equipment,
                    date = item.Date,
                    state = GetNameState(item.EquipmentStateId)
                });
            }
            return list;
        }

        public IEnumerable<ViewsObj.ViewEquipment.State> GetStateHistories(string name)
        {
            var equipment = GetEquipment(name);
            var context = new postgresContext();
            var res = context.EquipmentStateHistories.Where(e => e.EquipmentId == equipment.Id).OrderBy(e => e.Date);
            List<ViewsObj.ViewEquipment.State> list = new();
            foreach (var item in res)
            {
                list.Add(new ViewsObj.ViewEquipment.State
                {
                    Name = equipment.Name,
                    Date = item.Date,
                    EquipmentState = GetNameState(item.EquipmentStateId)
                });
            }
            return list;
        }

        public bool PostStateHistory(EquipmentStateHistory stateHistory)
        {
            var context = new postgresContext();
            context.EquipmentStateHistories.Add(stateHistory);
            context.SaveChanges();
            return true;
        }

        public bool DeleteStateHistory(Guid id)
        {
            var context = new postgresContext();
            context.EquipmentStateHistories.Remove(GetStateHistory(id));
            context.SaveChanges();
            return true;
        }

        public bool PutStateHistory(EquipmentStateHistory stateHistory)
        {
            var context = new postgresContext();
            context.EquipmentStateHistories.Update(stateHistory);
            context.SaveChanges();
            return true;
        }

        private static EquipmentStateHistory GetStateHistory(Guid id)
        {
            var context = new postgresContext();
            return context.EquipmentStateHistories.Where(e => e.EquipmentId == id).FirstOrDefault();
        }
        private static string GetNameEquipment(Guid id)
        {
            var context = new postgresContext();
            return context.Equipment.Where(e => e.Id == id).First().Name;
        }
        private static Equipment GetEquipment(string name)
        {
            var context = new postgresContext();
            return context.Equipment.Where(e => e.Name == name).First();
        }
        private static string GetNameState(Guid id)
        {
            var context = new postgresContext();
            return context.EquipmentStates.Where(e => e.Id == id).First().Name;
        }
    }
}
