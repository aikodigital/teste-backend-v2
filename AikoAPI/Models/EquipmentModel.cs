using System;
using System.ComponentModel.DataAnnotations;

namespace AikoAPI.Models
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