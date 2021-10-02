using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Queries.RequestModels
{
    public class ListCurrentPositionsOfEquipmentsQuery : 
        IRequest<IReadOnlyList<EquipmentPositionHistory>>
    {
    }
}