using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    [Table("equipment_position_history")]
    [Keyless]
    public class EquipmentPositionHistory
    {
        public Guid equipment_id { get; set; }
        
        public DateTime date { get; set; }
        
        public float lat { get; set; }
        
        public float lon { get; set; }
        
        [ForeignKey("equipment_id")]
        public virtual Equipment equipment { get; set; }
    }
}