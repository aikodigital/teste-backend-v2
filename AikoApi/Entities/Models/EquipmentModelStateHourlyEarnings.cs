using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    [Table("equipment_model_state_hourly_earnings")]
    [Keyless]
    public class EquipmentModelStateHourlyEarnings
    {
        [Column("equipment_model_id")]
        [ForeignKey("equipment_model_id")]
        public Guid EquipmentModelId { get; set; }

        [Column("equipment_state_id")]
        [ForeignKey("equipment_state_id")]
        public Guid EquipmentStateId { get; set; }
        
        [Column("value")]
        public double Value { get; set; }
        
        public virtual EquipmentModel EquipmentModel { get; set; }

        public virtual EquipmentState EquipmentState { get; set; }
        
    }
}