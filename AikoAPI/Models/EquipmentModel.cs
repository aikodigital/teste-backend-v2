using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AikoAPI.Models
{
    [Table("equipment_model")]
    public class EquipmentModel
    {
        [Column("id", TypeName = "uuid"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        
        [Column("name", TypeName = "text"), Required]
        public String Name { get; set; }
    }
}