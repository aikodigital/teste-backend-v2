using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Models
{
    [Table("equipment_state", Schema = "operation")]
    public class EquipmentState
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
    }
}
