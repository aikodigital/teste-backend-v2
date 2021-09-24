using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("equipment_model_state_hourly_earnings")]
    public class Equipment_model_state_hourly_earnings : AuditableBaseEntity
    {
        public Guid id { get; set; }

        public Guid equipment_model_id { get; set; }
        [ForeignKey("equipment_model_id")]
        public Equipment_Model Equipment_Model { get; set; }

        public int equipment_state_id { get; set; }
        [ForeignKey("equipment_state_id")]
        public Equipment_State Equipment_State { get; set; }

        public double value { get; set; }
    }
}
