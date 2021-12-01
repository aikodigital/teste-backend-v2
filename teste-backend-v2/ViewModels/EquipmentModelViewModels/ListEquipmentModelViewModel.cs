using System;
using System.ComponentModel.DataAnnotations;

namespace teste_backend_v2.ViewModels.EquipmentModelViewModels
{
    public class ListEquipmentModelViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
