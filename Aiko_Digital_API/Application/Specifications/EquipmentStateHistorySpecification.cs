using System;
using Application.Helpers;
using Domain;

namespace Application.Specifications
{
    public class EquipmentStateHistorySpecification : 
        BaseSpecification<EquipmentStateHistory>
    {
        public EquipmentStateHistorySpecification()
        {
            AddInclude(x=>x.Equipment.EquipmentModel);
            AddInclude(x=>x.EquipmentState);
        }
        
        public EquipmentStateHistorySpecification(Guid equipmentId) :
            base(x=>x.EquipmentId == equipmentId)
        {
            AddInclude(x=>x.Equipment.EquipmentModel);
            AddInclude(x=>x.EquipmentState);
        }
        
        public EquipmentStateHistorySpecification(Guid equipmentId, DateTime date) :
            base(x=>x.EquipmentId == equipmentId && x.Date == date)
        {
            AddInclude(x=>x.Equipment.EquipmentModel);
            AddInclude(x=>x.EquipmentState);
        }
    }
}