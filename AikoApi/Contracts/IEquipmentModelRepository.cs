using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IEquipmentModelRepository : IRepositoryBase<EquipmentModel>
    {
        IEnumerable<EquipmentModel> GetAll();

        EquipmentModel GetById(Guid id);

        EquipmentModel GetByName(string name);
    }
}