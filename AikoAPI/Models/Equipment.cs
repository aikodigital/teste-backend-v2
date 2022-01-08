using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AikoAPI.Models
{
    [Table("equipment")]
    public class Equipment
    { 
        [Column("id", TypeName = "uuid"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        
        [Column("equipment_model_id", TypeName = "uuid"), Required, ForeignKey("EquipmentModel")]
        public Guid EquipmentModelId { get; set; }
        
        [Column("name", TypeName = "text"), Required]
        public String Name { get; set; }

        public EquipmentModel EquipmentModel { get; set; }
    }
}