using System;
using Entities.Models;

namespace Entities.DTOs
{
    public class EquipmentDTO
    {
        public Guid Id { get; set; }
        
        public Guid EquipmentModelId { get; set; }
        
        public string Name { get; set; }  
        
        public EquipmentModel EquipmentModel { get; set; }
    }
}