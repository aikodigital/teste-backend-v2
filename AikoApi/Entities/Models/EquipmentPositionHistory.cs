using System;

namespace Entities.Models
{
    public class EquipmentPositionHistory
    {
        public Equipment Equipment { get; set; }

        public DateTime Date { get; set; }

        public string Lat { get; set; }
        
        public string Long { get; set; }
    }
}