using System.Collections.Generic;

namespace Domain.Models
{
    public class Model : Entity
    {
        public string Name { get; set; }
        
        /* EF Relations */
        public ICollection<Equipment> Equipments { get; set; }
        public ICollection<ModelStateHourlyEarnings> ModelStateHourlyEarnings { get; set; }
    }
}