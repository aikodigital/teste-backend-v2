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
            AddOrderBy(x=>x.Equipment.Name);
        }
        
        public EquipmentStateHistorySpecification(Guid equipmentId, DateTime date) :
            base(x=>x.EquipmentId == equipmentId && x.Date == date)
        {
            AddInclude(x=>x.Equipment.EquipmentModel);
            AddInclude(x=>x.EquipmentState);
        }

        public EquipmentStateHistorySpecification(Guid equipmentId, DateTime date, 
            Guid equipmentStateId) : base(x=>x.EquipmentId == equipmentId 
                                                 && x.Date.Day == date.Day && x.EquipmentStateId == equipmentStateId)
        {
            AddInclude(x=>x.Equipment.EquipmentModel);
            AddInclude(x=>x.EquipmentState);
        }
        
        public EquipmentStateHistorySpecification(Guid equipmentId, DateTime date, 
            string state) : base(x=>x.EquipmentId == equipmentId 
                                             && x.Date.Day == date.Day && 
                                             x.EquipmentState.Name.ToUpper() == state.ToUpper())
        {
            AddInclude(x=>x.Equipment.EquipmentModel);
            AddInclude(x=>x.EquipmentState);
        }
    }
}