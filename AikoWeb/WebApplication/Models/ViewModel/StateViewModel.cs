using System.Collections.Generic;

namespace WebApplication.Models.ViewModel
{
    public class EquipmentStateHistoryViewModel : LayoutViewModel<EquipmentStateHistoryViewModel>
    {
        public IEnumerable<EquipmentStateHistory> EquipmentHistories { get; set; }

        public EquipmentStateHistoryViewModel()
        {
            ViewTitle = "Equipment State History";
        }
    }
}