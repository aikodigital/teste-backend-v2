using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AikoAPI.Models
{
    public class EquipmentStateHistory
    {
        [ForeignKey("Equipment")]
        [Required]
        public Guid equipment_id { get; set; }
        [Required]
        public DateTime date { get; set; }
        
        [ForeignKey("EquipmentState")]
        [Required]
        public Guid equipment_state_id { get; set; }
        
        public Equipment equip { get; set; }
    }
}