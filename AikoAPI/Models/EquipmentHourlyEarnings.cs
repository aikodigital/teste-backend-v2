using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AikoAPI.Models
{
    [Table("equipment_model_state_hourly_earnings")]
    public class EquipmentHourlyEarnings
    {
        [Column("equipment_model_id", TypeName = "uuid"), Required]
        public Guid EquipmentModelId { get; set; }

        [Column("equipment_state_id", TypeName = "uuid"), Required]
        public Guid EquipmentStateId { get; set; }

        [Column("value", TypeName = "float4"), Required]
        public Double Value { get; set; }
        
        public EquipmentModel EquipmentModel { get; set; }
        
        public EquipmentState EquipmentState { get; set; }
    }
}
