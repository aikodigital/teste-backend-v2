using Domain;

namespace Application.Dtos
{
    public class EquipmentModelStateHourlyEarningDto
    {
        public float Value { get; set; }
        public EquipmentModel EquipmentModel { get; set; }
        public EquipmentState EquipmentState { get; set; }
    }
}