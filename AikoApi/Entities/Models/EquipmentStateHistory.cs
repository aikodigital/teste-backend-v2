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
        [Column("equipment_id")]
        [ForeignKey("equipment_id")]
        public Guid EquipmentId { get; set; }
        
        [Column("equipment_state_id")]
        [ForeignKey("equipment_state_id")]
        public Guid EquipmentStateId { get; set; }
        
        [Column("date")]
        public DateTime Date { get; set; }
        
        public virtual Equipment Equipment { get; set; }
        
        public virtual EquipmentState EquipmentState { get; set; }
    }
}