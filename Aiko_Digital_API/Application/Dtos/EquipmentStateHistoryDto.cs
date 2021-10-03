using System;
using Domain;

namespace Application.Dtos
{
    public class EquipmentStateHistoryDto
    {
        public DateTime Date { get; set; }
        public EquipmentDto Equipment { get; set; }
        public EquipmentState EquipmentState { get; set; }
        
    }
}