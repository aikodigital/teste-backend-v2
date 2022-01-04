using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AikoAPI.Models
{
    public class EquipmentHourlyEarnings
    {
        [ForeignKey(("EquipmentModel"))]
        [Required]
        public Guid equipment_model_id { get; set; }

        [ForeignKey(("EquipmentState"))]
        [Required]
        public Guid equipment_state_id { get; set; }

        [Required]
        public Double value { get; set; }
    }
}
