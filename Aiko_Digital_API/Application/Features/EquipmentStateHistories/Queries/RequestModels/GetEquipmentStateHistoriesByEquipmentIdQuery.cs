using System;
using System.Collections.Generic;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Queries.RequestModels
{
    public class GetEquipmentStateHistoriesByEquipmentIdQuery : 
        IRequest<IReadOnlyList<EquipmentStateHistoryDto>>
    {
        public Guid EquipmentId { get; set; }
    }
}