using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("equipment")]
    public partial class Equipment
    {
        [Key]
        public Guid id { get; set; }
        
        public Guid equipment_model_id { get; set; }

        public string name { get; set; }

        [ForeignKey("equipment_model_id")]
        public virtual EquipmentModel equipment_model { get; set; }
        
    }
}