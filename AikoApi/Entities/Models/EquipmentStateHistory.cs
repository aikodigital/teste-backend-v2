using System;

namespace Entities.Models
{
    public class EquipmentStateHistory
    {
        public Equipment Equipment { get; set; }

        public DateTime Date { get; set; }

        public EquipmentState EquipmentState { get; set; }
    }
}