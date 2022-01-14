using System;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class EquipmentViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid ModelId { get; set; }
        public ModelViewModel Model { get; set; }
    }
}