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
    public class EquipmentRepository : RepositoryBase<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<List<Equipment>> GetAll() => ReadAll().OrderBy(x => x.id).ToListAsync();

        public Task<Equipment> GetById(Guid id) => ReadByCondition(x => x.id.Equals(id)).FirstOrDefaultAsync();

        public Task<List<Equipment>> GetByEquipmentModelId(Guid id) =>
            ReadByCondition(x => x.equipment_model_id.Equals(id)).ToListAsync();

        public Task<List<Equipment>> GetByName(string name) => ReadByCondition(x => x.name.Contains(name)).ToListAsync();
        
        public Task<Equipment> Post(Equipment model) => Create(model);

        public Task<Equipment> Put(Equipment model) => Update(model);

        public Task<bool> Remove(Equipment model) => Delete(model);
    }
}