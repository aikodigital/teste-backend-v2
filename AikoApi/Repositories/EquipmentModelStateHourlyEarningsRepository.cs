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
    public class EquipmentModelStateHourlyEarningsRepository : RepositoryBase<EquipmentModelStateHourlyEarnings>,
        IEquipmentModelStateHourlyEarningsRepository
    {
        public EquipmentModelStateHourlyEarningsRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<List<EquipmentModelStateHourlyEarnings>> GetAll() => ReadAll().Include(x => x.EquipmentModel).Include(x => x.EquipmentState).OrderBy(x => x.EquipmentModelId).ToListAsync();

        public Task<List<EquipmentModelStateHourlyEarnings>> GetByEquipmentModelId(Guid id) =>
            ReadByCondition(x => x.EquipmentModelId.Equals(id)).Include(x => x.EquipmentModel).Include(x => x.EquipmentState).ToListAsync();

        public Task<List<EquipmentModelStateHourlyEarnings>> GetByEquipmentStateId(Guid id) =>
            ReadByCondition(x => x.EquipmentStateId.Equals(id)).Include(x => x.EquipmentModel).Include(x => x.EquipmentState).ToListAsync();

        public Task<List<EquipmentModelStateHourlyEarnings>> GetByValue(float value) =>
            ReadByCondition(x => x.Value.Equals(value)).Include(x => x.EquipmentModel).Include(x => x.EquipmentState).ToListAsync();

        public Task<EquipmentModelStateHourlyEarnings> Post(EquipmentModelStateHourlyEarnings model) => Create(model);

        public Task<EquipmentModelStateHourlyEarnings> Put(EquipmentModelStateHourlyEarnings model) => Update(model);

        public Task<bool> Remove(EquipmentModelStateHourlyEarnings model) => Delete(model);
    }
}