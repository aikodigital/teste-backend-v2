using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DTOs
{
    public class EquipmentModelStateHourlyEarningsDTO
    {
        public Guid equipment_model_id { get; set; }

        public Guid equipment_state_id { get; set; }
        
        public double value { get; set; }
    }
}