using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Models
{
    [Table("equipment_position_history", Schema = "operation")]
    public class EquipmentPositionLastHistory
    {
        public DateTime date { get; set; }
        public Single equipment_position_lat { get; set; }
        public Single equipment_position_lon { get; set; }
        public Guid equipment_id { get; set; }
        public string equipment_name { get; set; }
        public Guid equipment_model_id { get; set; }
        public string equipment_model_name { get; set; }
    }
}
