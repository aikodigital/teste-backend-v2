using System;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Commands.RequestModels
{
    public class CreateEquipmentStateHistoryCommand : IRequest<EquipmentStateHistory>
    {
        public Guid EquipmentId { get; set; }
        public Guid EquipmentStateId { get; set; }
    }
}