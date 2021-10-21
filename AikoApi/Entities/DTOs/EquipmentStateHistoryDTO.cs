using System;

namespace Entities.DTOs
{
    public class EquipmentStateHistoryDTO
    {
        public Guid equipment_id { get; set; }
        
        public Guid equipment_state_id { get; set; }

        public DateTime date { get; set; }

    }
}