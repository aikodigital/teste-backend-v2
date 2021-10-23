using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class EquipmentPositionHistoryRepository : RepositoryBase<EquipmentPositionHistory>, IEquipmentPositionHistoryRepository
    {
        public EquipmentPositionHistoryRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<List<EquipmentPositionHistory>> GetAll() => ReadAll().Include(x => x.equipment).OrderBy(x => x.equipment_id).ToListAsync();

        public Task<List<EquipmentPositionHistory>> GetByEquipmentId(Guid id) => ReadByCondition(x => x.equipment_id.Equals(id)).Include(x => x.equipment).ToListAsync();

        public Task<List<EquipmentPositionHistory>> GetByDate(DateTime dateTime) =>
            ReadByCondition(x => x.date.Equals(dateTime)).Include(x => x.equipment).ToListAsync();

        public Task<List<EquipmentPositionHistory>> GetByLatitude(float lat) =>
            ReadByCondition(x => x.lat.Equals(lat)).Include(x => x.equipment).ToListAsync();

        public Task<List<EquipmentPositionHistory>> GetByLongitude(float lon) => ReadByCondition(x => x.lon.Equals(lon)).Include(x => x.equipment).ToListAsync();

        public Task<List<EquipmentPositionHistory>> GetByPosition(Position position) =>
            ReadByCondition(x => x.lat.Equals(position.lat) && x.lon.Equals(position.lon)).Include(x => x.equipment).ToListAsync();

        public Task<EquipmentPositionHistory> GetCurrentEquipmentPosition(Guid equipmentId) =>
            ReadByCondition(x => x.equipment_id.Equals(equipmentId))
                .OrderByDescending(x => x.date)
                .FirstOrDefaultAsync();

        public Task<EquipmentPositionHistory> Post(EquipmentPositionHistory model) => Create(model);

        public Task<EquipmentPositionHistory> Put(EquipmentPositionHistory model) => Update(model);

        public Task<bool> Remove(EquipmentPositionHistory model) => Delete(model);
    }
}