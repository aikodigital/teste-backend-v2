using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModels.Queries.RequestModels
{
    public class ListAllEquipmentModelsQuery : IRequest<IReadOnlyList<EquipmentModel>>
    {
    }
}