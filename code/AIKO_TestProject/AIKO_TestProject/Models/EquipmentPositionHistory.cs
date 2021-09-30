using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Models
{
    [Table("equipment_position_history", Schema = "operation")]
    public class EquipmentPositionHistory
    {
        public Guid equipment_id { get; set; }
        public int lat { get; set; }
        public int lon { get; set; }
        public DateTime date { get; set; }

    }
}
