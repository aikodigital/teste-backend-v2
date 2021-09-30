using System;
using Application.Helpers;
using Domain;

namespace Application.Specifications
{
    public class EquipmentStateSpecification : BaseSpecification<EquipmentState>
    {
        public EquipmentStateSpecification()
        {
            AddOrderBy(x=>x.Name);
        }
        
        public EquipmentStateSpecification(string name, string color)
        : base(x=>x.Name.ToUpper() == name.ToUpper() 
                  || x.Color.ToUpper() == color.ToUpper())
        {
        }
        
        public EquipmentStateSpecification(Guid id, string name, string color)
            : base(x=>x.Id != id && (x.Name.ToUpper() == name.ToUpper() 
                                     || x.Color.ToUpper() == color.ToUpper()))
        {
        }
    }
}