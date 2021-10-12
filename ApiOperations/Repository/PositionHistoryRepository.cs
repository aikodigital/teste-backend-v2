using ApiOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Repository
{
    public class PositionHistoryRepository : IPositionHistoryRepository
    {
        public object GetLastPosition(Guid id)
        {
            var context = new postgresContext();
            var res = context.EquipmentPositionHistories.Where(e => e.EquipmentId == id).OrderByDescending(e => e.Date).First();
            return new { equipment = GetNameEquipment(id), date = res.Date, lat = res.Lat, lon = res.Lon };
        }

        public IEnumerable<object> GetPositionHistories(Guid id)
        {
            var context = new postgresContext();
            List<object> list = new();
            var res = context.EquipmentPositionHistories.Where(e => e.EquipmentId == id).OrderBy(e => e.Date);
            var equipment = GetNameEquipment(id);
            foreach (var item in res)
            {
                list.Add(new
                {
                    equipment,
                    date = item.Date,
                    lat = item.Lat,
                    lon = item.Lon
                });
            }
            return list;
        }

        public IEnumerable<ViewsObj.ViewEquipment.Position> GetPositionHistories(string name)
        {
            var equipment = GetNameEquipment(name);
            var context = new postgresContext();
            List<ViewsObj.ViewEquipment.Position> list = new();
            var res = context.EquipmentPositionHistories.Where(e => e.EquipmentId == equipment.Id).OrderBy(e => e.Date);
            foreach (var item in res)
            {
                list.Add(new ViewsObj.ViewEquipment.Position
                {
                    Equipment = equipment.Name,
                    Date = item.Date,
                    Latitude = item.Lat,
                    Longitude = item.Lon
                });
            }
            return list;
        }

        public bool PostPositionHistory(EquipmentPositionHistory positionHistory)
        {
            var context = new postgresContext();
            context.EquipmentPositionHistories.Add(positionHistory);
            context.SaveChanges();
            return true;
        }

        public bool DeletePositionHistory(Guid id)
        {
            var context = new postgresContext();
            context.EquipmentPositionHistories.Remove(GetPositionHistory(id));
            context.SaveChanges();
            return true;
        }

        public bool PutPositionHistory(EquipmentPositionHistory positionHistory)
        {
            var context = new postgresContext();
            context.EquipmentPositionHistories.Update(positionHistory);
            context.SaveChanges();
            return true;
        }

        private static EquipmentPositionHistory GetPositionHistory(Guid id)
        {
            var context = new postgresContext();
            return context.EquipmentPositionHistories.Where(e => e.EquipmentId == id).FirstOrDefault();
        }

        private static string GetNameEquipment(Guid id)
        {
            var context = new postgresContext();
            return context.Equipment.Where(e => e.Id == id).First().Name;
        }
        private static Equipment GetNameEquipment(string name)
        {
            var context = new postgresContext();
            return context.Equipment.Where(e => e.Name == name).First();
        }
    }
}
