using System;

namespace Entities.DTOs
{
    public class EquipmentDTO
    {
        public Guid id { get; set; }
        
        public Guid equipment_model_id { get; set; }
        
        public string name { get; set; }        
    }
}