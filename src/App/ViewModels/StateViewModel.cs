using System;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class StateViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Color { get; set; }
    }
}