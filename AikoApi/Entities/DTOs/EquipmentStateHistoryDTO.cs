using System;
using Entities.Models;

namespace Entities.DTOs
{
    public class EquipmentStateHistoryDTO
    {
        public Guid EquipmentId { get; set; }
        
        public Guid EquipmentStateId { get; set; }

        public DateTime Date { get; set; }
        
        public Equipment Equipment { get; set; }
        
        public EquipmentState EquipmentState { get; set; }

    }
}