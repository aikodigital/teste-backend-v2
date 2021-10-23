using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    [Table("equipment_model_state_hourly_earnings")]
    [Keyless]
    public class EquipmentModelStateHourlyEarnings
    {
        public Guid equipment_model_id { get; set; }

        public Guid equipment_state_id { get; set; }
        
        public double value { get; set; }
        
        [ForeignKey("equipment_model_id")]
        public virtual EquipmentModel equipment_model { get; set; }

        [ForeignKey("equipment_state_id")]
        public virtual EquipmentState equipment_state { get; set; }
        
    }
}