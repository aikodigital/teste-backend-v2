using System;

namespace Domain.Models
{
    public class ModelStateHourlyEarnings
    {
        public double Value { get; set; }
        public Guid ModelId { get; set; }
        public Model Model { get; set; }
        public Guid StateId { get; set; }
        public State State { get; set; }
    }
}