using System;
using Domain;

namespace Application.Dtos
{
    public class EquipmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EquipmentModel EquipmentModel { get; set; }
    }
}