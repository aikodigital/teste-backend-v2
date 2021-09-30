using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject.Models
{
    [Table("equipment_model_state_hourly_earnings", Schema = "operation")]
    public class EquipmentModelStateHourlyEarnings
    {
        public Guid equipment_model_id { get; set; }
        public Guid equipment_state_id { get; set; }
        public Single value { get; set; }
    }
}
