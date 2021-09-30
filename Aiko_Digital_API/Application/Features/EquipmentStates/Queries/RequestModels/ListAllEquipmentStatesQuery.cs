using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStates.Queries.RequestModels
{
    public class ListAllEquipmentStatesQuery : IRequest<IReadOnlyList<EquipmentState>>
    {
    }
}