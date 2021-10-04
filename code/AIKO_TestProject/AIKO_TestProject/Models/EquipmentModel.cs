using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Models
{
    [Table("equipment_model", Schema = "operation")]
    public class EquipmentModel
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
    }

}
