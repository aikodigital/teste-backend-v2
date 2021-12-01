using System;
using System.Collections.Generic;

#nullable disable

namespace teste_backend_v2.Models
{
    public partial class EquipmentPositionHistory
    {
        public Guid EquipmentId { get; set; }
        public DateTime Date { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
