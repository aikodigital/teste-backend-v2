using System;
using System.ComponentModel.DataAnnotations;

namespace teste_backend_v2.ViewModels.EquipmentPositionViewModels
{
    public class ListLastEquipmentPositionViewModel
    {
        [Key]
        public Guid EquipmentId { get; set; }

        public string Equipment { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Date { get; set; }
    }
}
