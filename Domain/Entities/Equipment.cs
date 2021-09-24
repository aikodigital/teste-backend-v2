using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("equipment")]
    public class Equipment : AuditableBaseEntity
    {
        public Guid id { get; set; }
        public string name { get; set; }

        public Guid equipment_model_id { get; set; }
        [ForeignKey("equipment_model_id")]
        public Equipment_Model Equipment_Model { get; set; }
    }
}
