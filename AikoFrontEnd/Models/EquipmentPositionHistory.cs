using System;

namespace AikoFrontEnd.Models
{
    public class EquipmentPositionHistory
    {
        public Guid EquipmentId { get; set; }
        public DateTime Date { get; set; }
        public Double Lat { get; set; }
        public Double Lon { get; set; }

        public Equipment Equipment { get; set; }
    }
}