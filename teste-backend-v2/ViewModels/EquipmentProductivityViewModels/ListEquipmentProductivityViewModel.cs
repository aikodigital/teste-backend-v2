using System.ComponentModel.DataAnnotations;

namespace teste_backend_v2.ViewModels.EquipmentProductivityViewModels
{
    public class ListEquipmentProductivityViewModel
    {
        public string Equipment { get; set; }

        [Display(Name = "Productivity (%)")]
        public string Productivity { get; set; }
        public string Date { get; set; }

    }
}
