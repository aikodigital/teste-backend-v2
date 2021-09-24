using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class EquipamentoDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public Guid equipment_model_id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
