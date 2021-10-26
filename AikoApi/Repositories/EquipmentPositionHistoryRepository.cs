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

        public Task<List<EquipmentPositionHistory>> GetAll() => ReadAll().Include(x => x.equipment).OrderBy(x => x.EquipmentId).ToListAsync();

        public Task<List<EquipmentPositionHistory>> GetByEquipmentId(Guid id) => ReadByCondition(x => x.EquipmentId.Equals(id)).Include(x => x.equipment).ToListAsync();

        public Task<List<EquipmentPositionHistory>> GetByDate(DateTime dateTime) =>
            ReadByCondition(x => x.Date.Equals(dateTime)).Include(x => x.equipment).ToListAsync();

        public Task<List<EquipmentPositionHistory>> GetByLatitude(float lat) =>
            ReadByCondition(x => x.Latitude.Equals(lat)).Include(x => x.equipment).ToListAsync();

        public Task<List<EquipmentPositionHistory>> GetByLongitude(float lon) => ReadByCondition(x => x.Longitude.Equals(lon)).Include(x => x.equipment).ToListAsync();

        public Task<List<EquipmentPositionHistory>> GetByPosition(Position position) =>
            ReadByCondition(x => x.Latitude.Equals(position.Latitude) && x.Longitude.Equals(position.Longitude)).Include(x => x.equipment).ToListAsync();

        public Task<EquipmentPositionHistory> GetCurrentEquipmentPosition(Guid equipmentId) =>
            ReadByCondition(x => x.EquipmentId.Equals(equipmentId))
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync();

        public Task<EquipmentPositionHistory> Post(EquipmentPositionHistory model) => Create(model);

        public Task<EquipmentPositionHistory> Put(EquipmentPositionHistory model) => Update(model);

        public Task<bool> Remove(EquipmentPositionHistory model) => Delete(model);
    }
}