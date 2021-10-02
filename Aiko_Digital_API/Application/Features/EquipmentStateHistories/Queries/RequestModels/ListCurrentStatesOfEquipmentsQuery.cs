using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Queries.RequestModels
{
    public class ListCurrentStatesOfEquipmentsQuery : 
        IRequest<IReadOnlyList<EquipmentStateHistory>>
    {
    }
}