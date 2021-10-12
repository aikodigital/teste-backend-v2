using ApiOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Repository
{
    public interface IStateHistoryRepository
    {
        IEnumerable<object> GetStateHistories(Guid id);
        IEnumerable<ViewsObj.ViewEquipment.State> GetStateHistories(string name);
        object GetLastState(Guid id);
        bool PostStateHistory(EquipmentStateHistory stateHistory);
        bool DeleteStateHistory(Guid id);
        bool PutStateHistory(EquipmentStateHistory stateHistory);
    }
}
