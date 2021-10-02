using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Queries.RequestModels
{
    public class ListAllEquipmentStateHistoriesQuery : 
        IRequest<IReadOnlyList<EquipmentStateHistory>>
    {
    }
}