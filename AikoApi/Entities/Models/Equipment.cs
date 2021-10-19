using System;

namespace Entities.Models
{
    public class Equipment
    {
        public Guid Id { get; set; }

        public EquipmentModel EquipmentModel { get; set; }

        public string Name { get; set; }
        
    }
}