using System;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class ModelViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}