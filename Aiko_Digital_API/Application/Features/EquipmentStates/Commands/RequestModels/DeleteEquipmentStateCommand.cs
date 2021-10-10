using System;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStates.Commands.RequestModels
{
    public class DeleteEquipmentStateCommand : IRequest<EquipmentState>
    {
        public Guid EquipmentStateId { get; set; }
    }
}