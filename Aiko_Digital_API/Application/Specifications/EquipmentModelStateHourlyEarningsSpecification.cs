using System;
using Application.Helpers;
using Domain;

namespace Application.Specifications
{
    public class EquipmentModelStateHourlyEarningsSpecification 
        : BaseSpecification<EquipmentModelStateHourlyEarning>
    {
        public EquipmentModelStateHourlyEarningsSpecification()
        {
            AddInclude(x=>x.EquipmentModel);
            AddInclude(x=>x.EquipmentState);
            AddOrderBy(x=>x.Value);
        }
        
        public EquipmentModelStateHourlyEarningsSpecification(Guid equipmentModelId)
        : base(x=>x.EquipmentModelId == equipmentModelId)
        {
            AddInclude(x=>x.EquipmentModel);
            AddInclude(x=>x.EquipmentState);
            AddOrderBy(x=>x.Value);
        }
        
        public EquipmentModelStateHourlyEarningsSpecification(Guid equipmentStateId, bool equipmentState)
            : base(x=>x.EquipmentStateId == equipmentStateId)
        {
            AddInclude(x=>x.EquipmentModel);
            AddInclude(x=>x.EquipmentState);
            AddOrderBy(x=>x.Value);
        }
        
        public EquipmentModelStateHourlyEarningsSpecification(float value)
            : base(x=>x.Value == value)
        {
            AddInclude(x=>x.EquipmentModel);
            AddInclude(x=>x.EquipmentState);
            AddOrderBy(x=>x.Value);
        }
        
        public EquipmentModelStateHourlyEarningsSpecification(Guid equipmentModelId, 
            Guid equipmentStateId, float value)
            : base(x=> x.EquipmentModelId == equipmentModelId 
                       && x.EquipmentStateId == equipmentStateId && x.Value == value)
        {
            AddInclude(x=>x.EquipmentModel);
            AddInclude(x=>x.EquipmentState);
        }
        
        public EquipmentModelStateHourlyEarningsSpecification(Guid equipmentModelId, 
            Guid equipmentStateId)
            : base(x=> x.EquipmentModelId == equipmentModelId 
                       && x.EquipmentStateId == equipmentStateId)
        {
            AddInclude(x=>x.EquipmentModel);
            AddInclude(x=>x.EquipmentState);
        }
    }
}