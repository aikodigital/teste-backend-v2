using System;

namespace Domain.Models
{
    public class StateHistory
    {
        public DateTime Date { get; set; }
        
        public Guid EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public Guid StateId { get; set; }
        public State State { get; set; }
    }
}