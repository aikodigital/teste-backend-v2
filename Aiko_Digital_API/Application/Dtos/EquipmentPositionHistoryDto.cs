using System;

namespace Application.Dtos
{
    public class EquipmentPositionHistoryDto
    {
        public DateTime Date { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public EquipmentDto Equipment { get; set; }
    }
}