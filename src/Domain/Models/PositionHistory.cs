using System;

namespace Domain.Models
{
    public class PositionHistory
    {
        public DateTime Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        /* EF Relations */
        public Guid EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}