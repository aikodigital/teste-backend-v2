using System;
using System.Collections.Generic;
using Contracts;
using Entities;
using Entities.Models;

namespace Repositories
{
    //Todo: implementar metodos
    public class EquipmentRepository : RepositoryBase<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(DatabaseContext context) : base(context)
        {
        }

        public IEnumerable<Equipment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Equipment GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipment> GetByEquipmentModelId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Equipment GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}