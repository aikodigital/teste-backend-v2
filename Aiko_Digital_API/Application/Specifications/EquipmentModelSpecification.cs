using System;
using Application.Helpers;
using Domain;

namespace Application.Specifications
{
    public class EquipmentModelSpecification : BaseSpecification<EquipmentModel>
    {
        public EquipmentModelSpecification()
        {
            AddOrderBy(x=>x.Name);
        }

        public EquipmentModelSpecification(Guid equipmentModelId) : 
            base(x=>x.Id == equipmentModelId)
        {
        }

        public EquipmentModelSpecification(string name) : 
            base(x=>x.Name.ToUpper() == name.ToUpper())
        {
        }
    }
}