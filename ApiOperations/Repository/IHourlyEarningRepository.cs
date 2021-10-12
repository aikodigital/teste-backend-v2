using ApiOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Repository
{
    public interface IHourlyEarningRepository
    {
        IEnumerable<object> GetHourlysEarnings();
        IEnumerable<object> GetHourlyEarning(string equipmentModel);
        bool PostHourlyEarning(EquipmentModelStateHourlyEarning hourlyEarning);
        bool DeleteHourlyEarning(Guid id);
        bool PutHourlyEarning(EquipmentModelStateHourlyEarning hourlyEarning);
    }
}
