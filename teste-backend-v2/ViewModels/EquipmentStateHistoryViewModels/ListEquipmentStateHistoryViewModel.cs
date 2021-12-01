using System;
using System.ComponentModel.DataAnnotations;

namespace teste_backend_v2.ViewModels.EquipmentStateHistoryViewModels
{
    public class ListEquipmentStateHistoryViewModel
    {
        public string Equipment { get; set; }

        [Display(Name = "State")]
        public string EquipmentState { get; set; }

        public string Date { get; set; }
    }
}
