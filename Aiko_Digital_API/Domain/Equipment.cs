﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public partial class Equipment
    {
        public Guid Id { get; set; }
        public Guid EquipmentModelId { get; set; }
        public string Name { get; set; }

        public virtual EquipmentModel EquipmentModel { get; set; }
    }
}
