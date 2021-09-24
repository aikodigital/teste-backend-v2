using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class ModelEquipamentoDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
