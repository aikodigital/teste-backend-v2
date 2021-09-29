using System;
using System.Collections.Generic;

#nullable disable

namespace API.Domain
{
    public partial class EquipmentState
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
