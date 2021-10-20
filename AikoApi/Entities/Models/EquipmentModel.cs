using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("equipment_model")]
    public class EquipmentModel
    {
        [Key]
        [Column("id")]
        public Guid id { get; set; }
        
        public string name { get; set; }
    }
}