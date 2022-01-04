using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AikoAPI.Models
{
    public class Equipment
    {  
        [Required]
        [Key]
        public Guid id { get; set; }
        [ForeignKey(("EquipmentModel"))]
        [Required]
        public Guid equipment_model_id { get; set; }
        [Required]
        public String name { get; set; }
        
        public List<EquipmentStateHistory> states { get; set; }
        
        public List<EquipmentPositionHistory> positions { get; set; }
    }
}