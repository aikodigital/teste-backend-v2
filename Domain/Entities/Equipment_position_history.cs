using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("equipment_position_history")]
    public class Equipment_position_history : AuditableBaseEntity
    {
        public Guid id { get; set; }

        public Guid equipment_id { get; set; }
        [ForeignKey("equipment_id")]
        public Equipment Equipment { get; set; }

        public DateTime date { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }

    }
}
