using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("equipment_model")]
    public class EquipmentModel
    {
        [Key]
        public Guid id { get; set; }
        
        public string name { get; set; }
    }
}