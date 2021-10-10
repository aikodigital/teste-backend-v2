using System;
using System.Collections.Generic;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Queries.RequestModels
{
    public class GetEquipmentPositionHistoriesByEquipmentIdQuery : 
        IRequest<IReadOnlyList<EquipmentPositionHistoryDto>>
    {
        public Guid EquipmentId { get; set; }
    }
}