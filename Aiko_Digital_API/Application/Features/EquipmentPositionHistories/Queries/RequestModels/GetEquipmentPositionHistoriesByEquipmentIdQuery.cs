using System;
using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Queries.RequestModels
{
    public class GetEquipmentPositionHistoriesByEquipmentIdQuery : 
        IRequest<IReadOnlyList<EquipmentPositionHistory>>
    {
        public Guid EquipmentId { get; set; }
    }
}