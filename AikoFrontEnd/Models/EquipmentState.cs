using System;
using System.ComponentModel.DataAnnotations;

namespace AikoAPI.Models
{
    public class EquipmentState
    {
        [Required]
        [Key]
        public Guid id { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public String color { get; set; }
    }
}