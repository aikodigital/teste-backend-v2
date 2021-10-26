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
    public class EquipmentStateRepository : RepositoryBase<EquipmentState>, IEquipmentStateRepository 
    {
        public EquipmentStateRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<List<EquipmentState>> GetAll() => ReadAll().OrderBy(x => x.Id).ToListAsync();

        public Task<EquipmentState> GetById(Guid id) => ReadByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();

        public Task<List<EquipmentState>> GetByName(string name) =>
            ReadByCondition(x => x.Name.Equals(name)).OrderBy(x => x.Id).ToListAsync();

        public Task<List<EquipmentState>> GetByColor(string color) =>
            ReadByCondition(x => x.Color.Equals(color)).OrderBy(x => x.Id).ToListAsync();
        
        public Task<EquipmentState> Post(EquipmentState model) => Create(model);

        public Task<EquipmentState> Put(EquipmentState model) => Update(model);

        public Task<bool> Remove(EquipmentState model) => Delete(model);
    }
}