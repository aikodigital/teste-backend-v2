using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class HistoricoEstadoEquipamentoDTO
    {
        public Guid id { get; set; }
        public Guid equipment_id { get; set; }

        public DateTime date { get; set; }

        public int equipment_state_id { get; set; }

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
