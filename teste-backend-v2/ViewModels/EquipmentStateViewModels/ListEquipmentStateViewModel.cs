using System;
using System.ComponentModel.DataAnnotations;

namespace teste_backend_v2.ViewModels.EquipmentStateViewModels
{
    public class ListEquipmentStateViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
