using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DTOs
{
    public class EquipmentStateDTO
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public string color { get; set; }
    }
}