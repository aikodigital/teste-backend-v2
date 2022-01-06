using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AikoAPI.Models
{
    [Table("equipment_state_history")]
    public class EquipmentStateHistory
    {
        [Column("equipment_id", TypeName = "uuid"), Required]
        public Guid EquipmentId { get; set; }
        
        [Column("date", TypeName = "timestamp"), Required]
        public DateTime Date { get; set; }
        
        [Column("equipment_state_id", TypeName = "uuid"), Required]
        public Guid EquipmentStateId { get; set; }
    }
}