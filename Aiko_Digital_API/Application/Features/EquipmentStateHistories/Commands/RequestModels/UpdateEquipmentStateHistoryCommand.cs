using System;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Commands.RequestModels
{
    public class UpdateEquipmentStateHistoryCommand : IRequest<EquipmentStateHistory>
    {
        public Guid EquipmentId { get; set; }
        public Guid EquipmentStateId { get; set; }
        public DateTime Date { get; set; }
        
    }
}