using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Models
{
    [Table("equipment_state_history", Schema = "operation")]
    public class EquipmentStateLastHistory 
    {
        public Guid equipment_id { get; set; }
        public Guid equipment_state_id { get; set; }
        public DateTime date { get; set; }
        public string equipment_state_name { get; set; }
        public string equipment_state_color { get; set; }
        public string equipment_name { get; set; }
        public Guid equipment_model_id { get; set; }
        public string equipment_model_name { get; set; }
    }
}
