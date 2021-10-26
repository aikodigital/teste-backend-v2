using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DTOs
{
    public class EquipmentModelStateHourlyEarningsDTO
    {
        public Guid EquipmentModelId { get; set; }

        public Guid EquipmentStateId { get; set; }
        
        public float Value { get; set; }
    }
}