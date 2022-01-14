using System;

namespace App.ViewModels
{
    public class PositionHistoryViewModel
    {
        public Guid EquipmentId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}