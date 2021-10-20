using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;

namespace Repositories
{
    //Todo: estruturar o repository
    public class EquipmentModelStateHourlyEarningsRepository : RepositoryBase<EquipmentModelStateHourlyEarnings>,
        IEquipmentModelStateHourlyEarningsRepository
    {
        public EquipmentModelStateHourlyEarningsRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable<EquipmentModelStateHourlyEarnings> ReadAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<EquipmentModelStateHourlyEarnings> ReadByCondition(
            Expression<Func<EquipmentModelStateHourlyEarnings, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<EquipmentModelStateHourlyEarnings> Create(EquipmentModelStateHourlyEarnings entity)
        {
            throw new NotImplementedException();
        }

        public Task<EquipmentModelStateHourlyEarnings> Update(EquipmentModelStateHourlyEarnings entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(EquipmentModelStateHourlyEarnings entity)
        {
            throw new NotImplementedException();
        }

        public EquipmentModelStateHourlyEarnings GetAll()
        {
            throw new NotImplementedException();
        }

        public EquipmentModelStateHourlyEarnings GetByEquipmentModelId(Guid id)
        {
            throw new NotImplementedException();
        }

        public EquipmentModelStateHourlyEarnings GetByEquipmentStateId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquipmentModelStateHourlyEarnings> GetByValue(float value)
        {
            throw new NotImplementedException();
        }
    }
}