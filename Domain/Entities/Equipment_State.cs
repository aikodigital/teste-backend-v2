using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("equipment_State")]
    public class Equipment_State
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
