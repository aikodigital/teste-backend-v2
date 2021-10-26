using System.Collections.Generic;

namespace WebApplication.Models.ViewModel
{
    public class HomeViewModel : LayoutViewModel<EquipmentStateHistoryViewModel>
    {
        public HomeViewModel()
        {
            ViewTitle = "Equipment State History";
        }
    }
}