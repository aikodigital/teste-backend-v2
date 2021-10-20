using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("equipment")]
    public class Equipment
    {
        [Key]
        public Guid id { get; set; }
        
        public Guid equipment_model_id { get; set; }
        
        [ForeignKey("equipment_model_id")]
        public EquipmentModel equipment_model { get; set; }
        
        public string name { get; set; }
        
    }
}