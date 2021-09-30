using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Models
{
    [Table("equipment", Schema = "operation")]
    public class Equipment
    {
        [Key]
        public Guid id { get; set; }
        public Guid equipment_model_id { get; set; }
        public string name { get; set; }
    }
}
