using System;

namespace AikoFrontEnd.Models
{
    public class EquipmentStateHistory
    {
        public Guid EquipmentId { get; set; }
        public DateTime Date { get; set; }
        public Guid EquipmentStateId { get; set; }

        public Equipment Equipment { get; set; }
    }
}