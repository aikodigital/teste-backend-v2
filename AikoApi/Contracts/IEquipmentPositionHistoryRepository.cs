using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IEquipmentPositionHistoryRepository : IRepositoryBase<EquipmentPositionHistory>
    {
        Task<List<EquipmentPositionHistory>> GetAll();

        Task<List<EquipmentPositionHistory>> GetByEquipmentId(Guid id);

        Task<List<EquipmentPositionHistory>> GetByDate(DateTime dateTime);

        Task<List<EquipmentPositionHistory>> GetByLatitude(float lat);
        
        Task<List<EquipmentPositionHistory>> GetByLongitude(float lon);
        
        Task<List<EquipmentPositionHistory>> GetByPosition(Position position);
        
        Task<EquipmentPositionHistory> Post(EquipmentPositionHistory model);

        Task<EquipmentPositionHistory> Put(EquipmentPositionHistory model);
        
        Task<bool> Remove(EquipmentPositionHistory model);
    }
}