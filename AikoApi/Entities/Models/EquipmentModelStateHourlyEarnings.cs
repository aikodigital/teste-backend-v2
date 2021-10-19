namespace Entities.Models
{
    public class EquipmentModelStateHourlyEarnings
    {
        public EquipmentModel EquipmentModel { get; set; }

        public EquipmentState EquipmentState { get; set; }

        public double Value { get; set; }
    }
}