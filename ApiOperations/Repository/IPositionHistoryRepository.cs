using ApiOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Repository
{
    public interface IPositionHistoryRepository
    {
        IEnumerable<object> GetPositionHistories(Guid id);
        IEnumerable<ViewsObj.ViewEquipment.Position> GetPositionHistories(string name);
        object GetLastPosition(Guid id);
        bool PostPositionHistory(EquipmentPositionHistory positionHistory);
        bool DeletePositionHistory(Guid id);
        bool PutPositionHistory(EquipmentPositionHistory positionHistory);
    }
}
