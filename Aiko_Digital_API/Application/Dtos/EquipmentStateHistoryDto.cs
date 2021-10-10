using System;
using Domain;

namespace Application.Dtos
{
    public class EquipmentStateHistoryDto
    {
        public DateTime Date { get; set; }
        public string Equipment { get; set; }
        public string EquipmentState { get; set; }
        
    }
}