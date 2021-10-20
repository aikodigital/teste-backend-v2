using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class EquipmentStateHistory
    {
        public Guid equipment_id { get; set; }
        
        [ForeignKey("equipment_id")]
        public Equipment equipment { get; set; }
        
        public Guid equipment_state_id { get; set; }
        
        [ForeignKey("equipment_state_id")]
        public EquipmentState equipmentState { get; set; }

        public DateTime date { get; set; }

    }
}