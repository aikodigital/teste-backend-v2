using System.Collections.Generic;

namespace Domain.Models
{
    public class State : Entity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        
        /* EF Relations */
        public ICollection<StateHistory> StateHistories { get; set; }
        public ICollection<ModelStateHourlyEarnings> ModelStateHourlyEarnings { get; set; }
    }
}