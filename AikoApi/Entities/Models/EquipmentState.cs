using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("equipment_state")]
    public class EquipmentState
    {
        [Key]
        public Guid id { get; set; }

        public string name { get; set; }

        public string color { get; set; }
    }
}