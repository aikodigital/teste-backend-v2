using System;

namespace WebApplication.Models
{
    public class EquipmentStateHistory
    {
        public DateTime Date { get; set; }
        
        public Equipment Equipment { get; set; }
        
        public EquipmentState EquipmentState { get; set; }

    }
}