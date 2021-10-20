using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class EquipmentModelStateHourlyEarnings
    {
        public Guid equipment_model_id { get; set; }

        public Guid equipment_state_id { get; set; }
        
        [ForeignKey("equipment_model_id")]
        public EquipmentModel equipmentModel { get; set; }

        [ForeignKey("equipment_state_id")]
        public EquipmentState equipmentState { get; set; }
        
        public double value { get; set; }
    }
}