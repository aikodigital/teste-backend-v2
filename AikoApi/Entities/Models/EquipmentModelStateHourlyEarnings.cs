using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("equipment_model_state_hourly_earnings")]
    public class EquipmentModelStateHourlyEarnings
    {
        public Guid equipment_model_id { get; set; }

        public Guid equipment_state_id { get; set; }
        
        [ForeignKey("equipment_model_id")]
        public EquipmentModel equipmentModel { get; set; }

        [ForeignKey("equipment_state_id")]
        public EquipmentState equipmentState { get; set; }
        
        [Key]
        public double value { get; set; }
    }
}