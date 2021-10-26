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
    public class EquipmentStateHistoryRepository : RepositoryBase<EquipmentStateHistory>,
        IEquipmentStateHistoryRepository
    {
        public EquipmentStateHistoryRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<List<EquipmentStateHistory>> GetAll() => ReadAll()
            .Include(x => x.Equipment)
            .Include(x => x.EquipmentState)
            .OrderBy(x => x.EquipmentId)
            .ToListAsync();

        public Task<List<EquipmentStateHistory>> GetByEquipmentId(Guid id) =>
            ReadByCondition(x => x.EquipmentId.Equals(id))
                .Include(x => x.Equipment)
                .Include(x => x.EquipmentState)
                .ToListAsync();

        public Task<List<EquipmentStateHistory>> GetByEquipmentStateId(Guid id) =>
            ReadByCondition(x => x.EquipmentStateId.Equals(id))
                .Include(x => x.Equipment)
                .Include(x => x.EquipmentState)
                .ToListAsync();

        public Task<List<EquipmentStateHistory>> GetByDate(DateTime datetime) =>
            ReadByCondition(x => x.Date.Equals(datetime))
                .Include(x => x.Equipment)
                .Include(x => x.EquipmentState)
                .ToListAsync();

        public Task<EquipmentStateHistory> GetCurrentEquipmentState(Guid equipmentId) =>
            ReadByCondition(x => x.EquipmentId.Equals(equipmentId))
                .Include(x => x.Equipment)
                .Include(x => x.EquipmentState)
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync();

        public Task<EquipmentStateHistory> Post(EquipmentStateHistory model) => Create(model);

        public Task<EquipmentStateHistory> Put(EquipmentStateHistory model) => Update(model);

        public Task<bool> Remove(EquipmentStateHistory model) => Delete(model);
    }
}