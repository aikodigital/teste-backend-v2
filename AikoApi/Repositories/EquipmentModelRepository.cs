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
    public class EquipmentModelRepository : RepositoryBase<EquipmentModel>, IEquipmentModelRepository
    {
        public EquipmentModelRepository(DatabaseContext context) : base(context)
        {
        }
        
        public Task<List<EquipmentModel>> GetAll() => ReadAll().OrderBy(x => x.id).ToListAsync();

        public Task<EquipmentModel> GetById(Guid id) => ReadByCondition(x => x.id.Equals(id)).FirstOrDefaultAsync();

        public Task<List<EquipmentModel>> GetByName(string name) => ReadByCondition(x => x.name.Contains(name)).ToListAsync();
        
        public async Task<EquipmentModel> Post(EquipmentModel model) => await Create(model);

        public Task<EquipmentModel> Put(EquipmentModel model) => Update(model);

        public Task<bool> Remove(EquipmentModel model) => Delete(model);
    }
}