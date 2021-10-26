using System.Collections.Generic;

namespace WebApplication.Models.ViewModel
{
    public class EquipmentViewModel : LayoutViewModel<EquipmentViewModel>
    {
        public IEnumerable<Equipment> Equipments { get; set; }

        public EquipmentViewModel()
        {
            ViewTitle = "Equipments";
        }
    }
}