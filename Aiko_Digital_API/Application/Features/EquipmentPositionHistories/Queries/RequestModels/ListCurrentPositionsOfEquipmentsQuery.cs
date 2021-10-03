using System.Collections.Generic;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Queries.RequestModels
{
    public class ListCurrentPositionsOfEquipmentsQuery : 
        IRequest<IReadOnlyList<EquipmentPositionHistoryDto>>
    {
    }
}