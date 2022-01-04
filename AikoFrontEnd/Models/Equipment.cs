using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AikoFrontEnd.Models
{
    public class Equipment
    {
        public Guid id { get; set; }
        public Guid equipment_model_id { get; set; }
        public String name { get; set; }
    }
}