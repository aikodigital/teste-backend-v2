using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("equipment_Model")]
    public class Equipment_Model : AuditableBaseEntity
    {
        public Guid id { get; set; }
        public string name { get; set; }
    }
}
