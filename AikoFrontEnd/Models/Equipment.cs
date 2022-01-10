using System;

namespace AikoFrontEnd.Models
{
    public class Equipment
    { 
        public Guid Id { get; set; }
        
        public Guid EquipmentModelId { get; set; }
        
        public String Name { get; set; }

        public EquipmentModel EquipmentModel { get; set; }
    }
}