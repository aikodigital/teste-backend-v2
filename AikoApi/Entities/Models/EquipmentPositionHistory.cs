using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class EquipmentPositionHistory
    {
        public Guid equipment_id { get; set; }
        
        [ForeignKey("equipment_id")]
        public Equipment equipment { get; set; }
        
        public DateTime date { get; set; }
        
        public string lat { get; set; }
        
        public string lon { get; set; }
    }
}