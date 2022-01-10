using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AikoAPI.Models
{
    [Table("equipment_position_history")]
    public class EquipmentPositionHistory
    {
        [Column("equipment_id", TypeName = "uuid"), Required, ForeignKey("Equipment")]
        public Guid EquipmentId { get; set; }
        
        [Column("date", TypeName = "timestamp"), Required]
        public DateTime Date { get; set; }
        
        [Column("lat", TypeName = "float4"), Required]
        public Double Lat { get; set; }
        
        [Column("lon", TypeName = "float4"), Required]
        public Double Lon { get; set; }

        public Equipment Equipment { get; set; }
    }
}