using ApiOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Repository
{
    public class HourlyEarningRepository : IHourlyEarningRepository
    {
        public IEnumerable<object> GetHourlysEarnings()
        {
            var context = new postgresContext();
            List<object> list = new();

            foreach (var item in context.EquipmentModelStateHourlyEarnings)
            {
                list.Add(new { equipmentModel = GetNameEquipmentModel(item.EquipmentModelId), equipmentState = GetNameEquipmentState(item.EquipmentStateId), item.Value });
            };
            return list;
        }

        public IEnumerable<object> GetHourlyEarning(string equipmentModel)
        {
            var context = new postgresContext();
            var idEquipModel = GetIdEquipmentModel(equipmentModel);
            var res = context.EquipmentModelStateHourlyEarnings.Where(e => e.EquipmentModelId == idEquipModel);
            List<object> list = new();
            foreach (var item in res)
            {
                list.Add(new { equipmentModel, equipmentState = GetNameEquipmentState(item.EquipmentStateId), item.Value });
            }
            return list;
        }

        public EquipmentModelStateHourlyEarning GetHourlyEarningGuid(Guid id)
        {
            var context = new postgresContext();
            return context.EquipmentModelStateHourlyEarnings.Where(e => e.EquipmentModelId == id).FirstOrDefault();
        }

        public bool PostHourlyEarning(EquipmentModelStateHourlyEarning hourlyEarning)
        {
            var context = new postgresContext();
            context.EquipmentModelStateHourlyEarnings.Add(hourlyEarning);
            context.SaveChanges();
            return true;
        }

        public bool DeleteHourlyEarning(Guid id)
        {
            var context = new postgresContext();
            context.EquipmentModelStateHourlyEarnings.Remove(GetHourlyEarningGuid(id));
            context.SaveChanges();
            return true;
        }

        public bool PutHourlyEarning(EquipmentModelStateHourlyEarning hourlyEarning)
        {
            var context = new postgresContext();
            context.EquipmentModelStateHourlyEarnings.Update(hourlyEarning);
            context.SaveChanges();
            return true;
        }

        private static string GetNameEquipmentModel(Guid id)
        {
            var context = new postgresContext();
            return context.EquipmentModels.Where(e => e.Id == id).FirstOrDefault().Name;
        }
        private static Guid GetIdEquipmentModel(string name)
        {
            var context = new postgresContext();
            return context.EquipmentModels.Where(e => e.Name == name).FirstOrDefault().Id;
        }
        private static string GetNameEquipmentState(Guid id)
        {
            var context = new postgresContext();
            return context.EquipmentStates.Where(e => e.Id == id).FirstOrDefault().Name;
        }
    }
}
