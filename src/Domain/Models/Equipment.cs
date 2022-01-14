using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Equipment : Entity
    {
        public string Name { get; set; }
        
        /* EF Relations */
        public Guid ModelId { get; set; }
        public Model Model { get; set; }
        public ICollection<PositionHistory> PositionHistories { get; set; }
        public ICollection<StateHistory> StateHistories { get; set; }
    }
}