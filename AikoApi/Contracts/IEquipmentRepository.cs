using System;
using System.Collections;
using System.Collections.Generic;
using Contracts;
using Entities.Models;

namespace Contracts
{
    public interface IEquipmentRepository : IRepositoryBase<Equipment>
    {
        IEnumerable<Equipment> GetAll();

        Equipment GetById(Guid id);

        IEnumerable<Equipment> GetByEquipmentModelId(Guid id);

        Equipment GetByName(string name);
    }
}