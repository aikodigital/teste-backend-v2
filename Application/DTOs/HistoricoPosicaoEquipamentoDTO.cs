using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class HistoricoPosicaoEquipamentoDTO
    {
        public Guid id { get; set; }

        public Guid equipment_id { get; set; }

        public DateTime date { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
