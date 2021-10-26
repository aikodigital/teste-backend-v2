using System;
using System.ComponentModel;

namespace WebApplication.Models
{
    public class EquipmentModel
    {
        [DisplayName("Equipment Model ID")]
        public Guid Id { get; set; }
        
        [DisplayName("Equipment Model")]
        public string Name { get; set; }
    }
}