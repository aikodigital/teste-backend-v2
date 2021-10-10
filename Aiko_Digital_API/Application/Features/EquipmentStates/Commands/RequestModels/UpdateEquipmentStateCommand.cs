using System;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStates.Commands.RequestModels
{
    public class UpdateEquipmentStateCommand : IRequest<EquipmentState>
    {
        public Guid EquipmentStateId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}