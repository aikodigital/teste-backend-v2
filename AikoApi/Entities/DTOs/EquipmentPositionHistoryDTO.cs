using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DTOs
{
    public class EquipmentPositionHistoryDTO
    {
        public Guid EquipmentId { get; set; }
        
        public DateTime Date { get; set; }
        
        public float Latitude { get; set; }
        
        public float Longitude { get; set; }
    }
}