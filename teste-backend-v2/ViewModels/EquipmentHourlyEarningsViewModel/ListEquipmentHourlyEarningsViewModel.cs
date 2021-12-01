using System;
using System.ComponentModel.DataAnnotations;

namespace teste_backend_v2.ViewModels.EquipmentHourlyEarningsViewModel
{
    public class ListEquipmentHourlyEarningsViewModel
    {
      
        public Guid EquipmentStateId { get; set; }
        
        [Key]
        public Guid EquipmentModelId { get; set; }

        [Display(Name = "Equipment model")]
        public string EquipmentModel { get; set; }

        [Display(Name = "Equipment state")]
        public string EquipmentState { get; set; }

        [Display(Name = "Value (R$)")]
        public string Value { get; set; }
    }
}
