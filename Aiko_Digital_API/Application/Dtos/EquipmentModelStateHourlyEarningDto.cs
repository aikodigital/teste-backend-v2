using Domain;

namespace Application.Dtos
{
    public class EquipmentModelStateHourlyEarningDto
    {
        public float Value { get; set; }
        public string EquipmentModel { get; set; }
        public string EquipmentState { get; set; }
    }
}