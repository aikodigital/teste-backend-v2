using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AikoFrontEnd.Models
{
    public class EquipmentPositionHistory
    {
        [Column("equipment_id")]
        [Required]
        public Guid equipment_id { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public Double lat { get; set; }
        [Required]
        public Double lon { get; set; }
        
        //public Equipment equip { get; set; }
    }
}