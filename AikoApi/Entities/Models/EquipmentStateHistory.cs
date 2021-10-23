using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    [Table("equipment_state_history")]
    [Keyless]
    public class EquipmentStateHistory
    {
        public Guid equipment_id { get; set; }
        
        [ForeignKey("equipment_id")]
        public virtual Equipment equipment { get; set; }
        
        public Guid equipment_state_id { get; set; }
        
        [ForeignKey("equipment_state_id")]
        public virtual EquipmentState equipment_state { get; set; }

        public DateTime date { get; set; }
    }
}