using System;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Commands.RequestModels
{
    public class DeleteEquipmentStateHistoryCommand : IRequest<EquipmentStateHistory>
    {
        public Guid EquipmentId { get; set; }
        public DateTime Date { get; set; }
    }
}