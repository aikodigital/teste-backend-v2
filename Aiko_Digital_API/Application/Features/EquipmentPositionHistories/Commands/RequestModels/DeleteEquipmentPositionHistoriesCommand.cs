using System;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Commands.RequestModels
{
    public class DeleteEquipmentPositionHistoriesCommand : IRequest<EquipmentPositionHistory>
    {
        public Guid EquipmentId { get; set; }
        public DateTime Date { get; set; }
    }
}