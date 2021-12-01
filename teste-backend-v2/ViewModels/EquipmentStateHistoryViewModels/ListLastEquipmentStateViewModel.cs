using System;
using System.ComponentModel.DataAnnotations;

namespace teste_backend_v2.ViewModels.EquipmentStateHistoryViewModels
{
    public class ListLastEquipmentStateViewModel
    {
        [Key]
        public Guid EquipmentId { get; set; }

        [Display(Name = "Equipment")]
        public string Equipment { get; set; }

        [Display(Name = "State")]
        public string EquipmentState { get; set; }

        public string Date { get; set; }
    }
}
