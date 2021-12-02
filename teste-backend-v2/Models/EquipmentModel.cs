using System;
using System.Collections.Generic;

#nullable disable

namespace teste_backend_v2.Models
{
    public partial class EquipmentModel
    {
        public EquipmentModel()
        {
            Equipment = new HashSet<Equipment>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
