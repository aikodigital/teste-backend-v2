using System;
using Application.Helpers;
using Domain;

namespace Application.Specifications
{
    public class EquipmentSpecification : BaseSpecification<Equipment>
    {
        public EquipmentSpecification()
        {
            AddInclude(x=>x.EquipmentModel);
            AddOrderBy(x=>x.Name);
        }

        public EquipmentSpecification(string name) 
        : base(x=>x.Name.ToUpper() == name.ToUpper())
        {
            AddInclude(x=>x.EquipmentModel);
        }
        
        public EquipmentSpecification(Guid id) 
            : base(x=>x.Id == id)
        {
            AddInclude(x=>x.EquipmentModel);
        }
        
        public EquipmentSpecification(Guid id, string name) 
            : base(x=>x.Id != id && x.Name == name)
        {
            AddInclude(x=>x.EquipmentModel);
        }
    }
}