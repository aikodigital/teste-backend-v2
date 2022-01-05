using System;
using System.ComponentModel.DataAnnotations;

namespace AikoFrontEnd.Models
{
    public class EquipmentModel
    {
        [Required]
        [Key]
        public Guid id { get; set; }
        [Required]
        public String name { get; set; }
    }
}