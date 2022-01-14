using System;

namespace App.ViewModels
{
    public class ModelStateHourlyEarningViewModel
    {
        public double Value { get; set; }
        public Guid ModelId { get; set; }
        public ModelViewModel Model { get; set; }
        public Guid StateId { get; set; }
        public StateViewModel State { get; set; }
    }
}