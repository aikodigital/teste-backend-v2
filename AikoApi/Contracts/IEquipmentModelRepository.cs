using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IEquipmentModelRepository : IRepositoryBase<EquipmentModel>
    {
        Task<List<EquipmentModel>> GetAll();

        Task<EquipmentModel> GetById(Guid id);

        Task<List<EquipmentModel>> GetByName(string name);

        Task<EquipmentModel> Post(EquipmentModel model);

        Task<EquipmentModel> Put(EquipmentModel model);

        Task<bool> Remove(EquipmentModel model);
    }
}