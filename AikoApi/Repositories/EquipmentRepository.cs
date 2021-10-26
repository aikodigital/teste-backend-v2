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

        public Task<List<Equipment>> GetAll() => ReadAll().Include(x => x.EquipmentModel).OrderBy(x => x.Id).ToListAsync();

        public Task<Equipment> GetById(Guid id) => ReadByCondition(x => x.Id.Equals(id)).Include(x => x.EquipmentModel).FirstOrDefaultAsync();

        public Task<List<Equipment>> GetByEquipmentModelId(Guid id) =>
            ReadByCondition(x => x.EquipmentModelId.Equals(id)).Include(x => x.EquipmentModel).ToListAsync();

        public Task<List<Equipment>> GetByName(string name) => ReadByCondition(x => x.Name.Contains(name)).Include(x => x.EquipmentModel).ToListAsync();
        
        public Task<Equipment> Post(Equipment model) => Create(model);

        public Task<Equipment> Put(Equipment model) => Update(model);

        public Task<bool> Remove(Equipment model) => Delete(model);
    }
}