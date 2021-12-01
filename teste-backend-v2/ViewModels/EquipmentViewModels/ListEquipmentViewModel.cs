using System;
using System.ComponentModel.DataAnnotations;

namespace teste_backend_v2.ViewModels.EquipmentViewModels
{
    public class ListEquipmentViewModel
    {        
        [Key]
        public Guid Id { get; set; }       

        [Display(Name = "Equipment model")]
        public string EquipmentModelId { get; set; }
               
        public string Name { get; set; }
    }
}
