using System.Collections.Generic;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Queries.RequestModels
{
    public class ListAllEquipmentPositionHistoriesQuery : 
        IRequest<IReadOnlyList<EquipmentPositionHistoryDto>>
    {
    }
}