using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    [Table("equipment_position_history")]
    [Keyless]
    public class EquipmentPositionHistory
    {
        [ForeignKey("equipment_id")]
        [Column("equipment_id")]
        public Guid EquipmentId { get; set; }
        
        [Column("date")]
        public DateTime Date { get; set; }
        
        [Column("lat")]
        public float Latitude { get; set; }
        
        [Column("lon")]
        public float Longitude { get; set; }
        
        public virtual Equipment equipment { get; set; }
    }
}