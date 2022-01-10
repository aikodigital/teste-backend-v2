using System;

namespace AikoFrontEnd.Models
{
    public class EquipmentHourlyEarnings
    {
        public Guid EquipmentModelId { get; set; }
        public Guid EquipmentStateId { get; set; }
        public Double Value { get; set; }
    }
}
