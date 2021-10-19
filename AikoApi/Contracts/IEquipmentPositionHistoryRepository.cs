using System;
using System.Collections;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IEquipmentPositionHistoryRepository : IRepositoryBase<EquipmentPositionHistory>
    {
        IEnumerable<EquipmentPositionHistory> GetAll();

        EquipmentPositionHistory GetByEquipmentId(Guid id);

        IEnumerable<EquipmentPositionHistory> GetByDate(DateTime dateTime);

        IEnumerable<EquipmentPositionHistory> GetByLat(float lat);
        
        IEnumerable<EquipmentPositionHistory> GetByLon(float lon);
        
        IEnumerable<EquipmentPositionHistory> GetByPosition(float lat, float lon);
    }
}