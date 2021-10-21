using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    //Todo: estruturar o repository
    public class EquipmentModelStateHourlyEarningsRepository : RepositoryBase<EquipmentModelStateHourlyEarnings>,
        IEquipmentModelStateHourlyEarningsRepository
    {
        public EquipmentModelStateHourlyEarningsRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<List<EquipmentModelStateHourlyEarnings>> GetAll() => ReadAll().Include(x => x.equipmentModel).Include(x => x.equipmentState).OrderBy(x => x.equipment_model_id).ToListAsync();

        public Task<List<EquipmentModelStateHourlyEarnings>> GetByEquipmentModelId(Guid id) =>
            ReadByCondition(x => x.equipment_model_id.Equals(id)).Include(x => x.equipmentModel).Include(x => x.equipmentState).ToListAsync();

        public Task<List<EquipmentModelStateHourlyEarnings>> GetByEquipmentStateId(Guid id) =>
            ReadByCondition(x => x.equipment_state_id.Equals(id)).Include(x => x.equipmentModel).Include(x => x.equipmentState).ToListAsync();

        public Task<List<EquipmentModelStateHourlyEarnings>> GetByValue(float value) =>
            ReadByCondition(x => x.value.Equals(value)).Include(x => x.equipmentModel).Include(x => x.equipmentState).ToListAsync();

        public Task<EquipmentModelStateHourlyEarnings> Post(EquipmentModelStateHourlyEarnings model) => Create(model);

        public Task<EquipmentModelStateHourlyEarnings> Put(EquipmentModelStateHourlyEarnings model) => Update(model);

        public Task<bool> Remove(EquipmentModelStateHourlyEarnings model) => Delete(model);
    }
}