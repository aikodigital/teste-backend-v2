using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("equipment_state_history")]
    public class Equipment_state_history : AuditableBaseEntity
    {
        public Guid id { get; set; }
        public Guid equipment_id { get; set; }
        [ForeignKey("equipment_id")]
        public Equipment Equipment { get; set; }

        public DateTime date { get; set; }

        public int equipment_state_id { get; set; }
        [ForeignKey("equipment_state_id")]
        public Equipment_State Equipment_State { get; set; }
    }
}
