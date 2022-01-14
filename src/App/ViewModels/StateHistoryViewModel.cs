using System;

using Domain.Models;

namespace App.ViewModels
{
    public class StateHistoryViewModel
    {
        public DateTime Date { get; set; }
        public Guid EquipmentId { get; set; }
        public EquipmentViewModel Equipment { get; set; }
        public Guid StateId { get; set; }
        public StateViewModel State { get; set; }
    }
}