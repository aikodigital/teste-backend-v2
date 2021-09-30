using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Models
{
    [Table("equipment_state_history", Schema = "operation")]
    public class EquipmentStateHistory
    {
        public Guid equipment_id { get; set; }
        public Guid equipment_state_id { get; set; }
        public DateTime date { get; set; }
    }
}
