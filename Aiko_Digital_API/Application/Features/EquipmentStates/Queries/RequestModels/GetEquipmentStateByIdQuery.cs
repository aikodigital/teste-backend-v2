using System;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStates.Queries.RequestModels
{
    public class GetEquipmentStateByIdQuery : IRequest<EquipmentState>
    {
        public Guid EquipmentStateId { get; set; }
    }
}