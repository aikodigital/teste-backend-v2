using System;
using Application.Helpers;
using Domain;

namespace Application.Specifications
{
    public class EquipmentPositionHistorySpecification : BaseSpecification<EquipmentPositionHistory>
    {
        public EquipmentPositionHistorySpecification()
        {
            AddInclude(x=>x.Equipment.EquipmentModel);
            AddOrderBy(x=>x.Equipment.Name);
        }
        
        public EquipmentPositionHistorySpecification(Guid equipmentId) 
            : base(x => x.EquipmentId == equipmentId)
        {
            AddInclude(x=>x.Equipment.EquipmentModel);
            AddOrderBy(x=>x.Equipment.Name);
        }

        public EquipmentPositionHistorySpecification(Guid equipmentId, 
        DateTime date, float lat, float lon)
        : base(x=>x.EquipmentId == equipmentId && 
                  x.Date == date && x.Lat == lat && x.Lon == lon)
        {
            AddInclude(x=>x.Equipment.EquipmentModel);
            AddOrderBy(x=>x.Equipment.Name);
        }
        
        public EquipmentPositionHistorySpecification(Guid equipmentId, 
            DateTime date)
            : base(x=>x.EquipmentId == equipmentId && 
                      x.Date == date)
        {
            AddInclude(x=>x.Equipment.EquipmentModel);
            AddOrderBy(x=>x.Equipment.Name);
        }
        
        
    }
}