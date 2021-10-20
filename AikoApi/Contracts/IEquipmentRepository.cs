using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Contracts
{
    public interface IEquipmentRepository : IRepositoryBase<Equipment>
    {
        Task<List<Equipment>> GetAll();

        Task<Equipment> GetById(Guid id);

        Task<List<Equipment>> GetByEquipmentModelId(Guid id);

        Task<List<Equipment>> GetByName(string name);

        Task<Equipment> Post(Equipment model);
        
        Task<Equipment> Put(Equipment model);

        Task<bool> Remove(Equipment model);
    }
}