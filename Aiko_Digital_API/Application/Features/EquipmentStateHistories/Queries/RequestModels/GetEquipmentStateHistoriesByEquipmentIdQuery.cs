using System;
using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Queries.RequestModels
{
    public class GetEquipmentStateHistoriesByEquipmentIdQuery : 
        IRequest<IReadOnlyList<EquipmentStateHistory>>
    {
        public Guid EquipmentId { get; set; }
    }
}