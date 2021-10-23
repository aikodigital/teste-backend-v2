using System;
using Entities.Models;

namespace Entities.DTOs
{
    public class EquipmentStateHistoryDTO
    {
        public Guid equipment_id { get; set; }
        
        public Guid equipment_state_id { get; set; }

        public DateTime date { get; set; }
        
        // public Equipment equipment { get; set; }
        //
        // public EquipmentState equipmentState { get; set; }

    }
}