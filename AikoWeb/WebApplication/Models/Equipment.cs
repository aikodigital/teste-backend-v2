using System;
using System.ComponentModel;

namespace WebApplication.Models
{
    public class Equipment
    {
        [DisplayName("ID")]
        public Guid Id { get; set; }
        
        [DisplayName("Equipment Model")]
        public EquipmentModel EquipmentModel { get; set; }
        
        [DisplayName("Equipment")]
        public string Name { get; set; }
    }
}