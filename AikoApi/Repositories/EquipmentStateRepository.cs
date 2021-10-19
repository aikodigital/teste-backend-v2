using System;
using System.Collections.Generic;
using Contracts;
using Entities;
using Entities.Models;

namespace Repositories
{
    //Todo: implementar os metodos
    public class EquipmentStateRepository : RepositoryBase<EquipmentState>, IEquipmentStateRepository 
    {
        public EquipmentStateRepository(DatabaseContext context) : base(context)
        {
        }

        public IEnumerable<EquipmentState> GetAll()
        {
            throw new NotImplementedException();
        }

        public EquipmentState GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public EquipmentState GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public EquipmentState GetByColor(string color)
        {
            throw new NotImplementedException();
        }
    }
}