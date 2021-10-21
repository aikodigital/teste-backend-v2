using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DTOs
{
    public class EquipmentPositionHistoryDTO
    {
        public Guid equipment_id { get; set; }
        
        public DateTime date { get; set; }
        
        public float lat { get; set; }
        
        public float lon { get; set; }
    }
}