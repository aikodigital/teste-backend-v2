using System.Collections.Generic;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Queries.RequestModels
{
    public class ListAllEquipmentStateHistoriesQuery : 
        IRequest<IReadOnlyList<EquipmentStateHistoryDto>>
    {
    }
}