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
    //Todo: estruturar o repository
    public class EquipmentStateHistoryRepository : RepositoryBase<EquipmentStateHistory>,
        IEquipmentStateHistoryRepository
    {
        public EquipmentStateHistoryRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<List<EquipmentStateHistory>> GetAll() => ReadAll().Include(x => x.equipment)
            .Include(x => x.equipmentState).OrderBy(x => x.equipment_id).ToListAsync();

        public Task<List<EquipmentStateHistory>> GetByEquipmentId(Guid id) =>
            ReadByCondition(x => x.equipment_id.Equals(id)).Include(x => x.equipment).Include(x => x.equipmentState)
                .ToListAsync();

        public Task<List<EquipmentStateHistory>> GetByEquipmentStateId(Guid id) =>
            ReadByCondition(x => x.equipment_state_id.Equals(id)).Include(x => x.equipment)
                .Include(x => x.equipmentState).ToListAsync();

        public Task<List<EquipmentStateHistory>> GetByDate(DateTime datetime) =>
            ReadByCondition(x => x.date.Equals(datetime)).Include(x => x.equipment).Include(x => x.equipmentState)
                .ToListAsync();

        public Task<EquipmentStateHistory> Post(EquipmentStateHistory model) => Create(model);

        public Task<EquipmentStateHistory> Put(EquipmentStateHistory model) => Update(model);

        public Task<bool> Remove(EquipmentStateHistory model) => Delete(model);
    }
}