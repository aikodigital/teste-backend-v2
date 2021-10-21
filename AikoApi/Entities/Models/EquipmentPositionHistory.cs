using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("equipment_position_history")]
    public class EquipmentPositionHistory
    {
        public Guid equipment_id { get; set; }
        
        [ForeignKey("equipment_id")]
        public Equipment equipment { get; set; }
        
        // adicionada chave primaria em 'date' para evitar o erro 
        // Unable to track an instance of type 'EquipmentPositionHistory' because it does not have a primary key. Only entity types with primary keys may be tracked."
        [Key]
        public DateTime date { get; set; }
        
        public float lat { get; set; }
        
        public float lon { get; set; }
    }
}