using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class GanhoHoraEstadoDTO
    {
        public Guid id { get; set; }

        public Guid equipment_model_id { get; set; }

        public int equipment_state_id { get; set; }

        public double value { get; set; }

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
