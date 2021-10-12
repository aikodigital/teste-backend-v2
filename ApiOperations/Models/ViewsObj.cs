using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Models
{
    public class ViewsObj
    {
        public class ViewEquipment
        {
            public class Equipment
            {
                public string Model { get; set; }
                public string Name { get; set; }
            }
            public class State
            {
                public string Name { get; set; }
                public DateTime Date { get; set; }
                public string EquipmentState { get; set; }
            }
            public class Position
            {
                public string Equipment { get; set; }
                public DateTime Date { get; set; }
                public float Latitude { get; set; }
                public float Longitude { get; set; }
            }
        }
    }
}
