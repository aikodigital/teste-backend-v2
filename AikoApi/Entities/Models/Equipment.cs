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
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("equipment_model_id")]
        [ForeignKey("equipment_model_id")]
        public Guid EquipmentModelId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public virtual EquipmentModel EquipmentModel { get; set; }
        
    }
}