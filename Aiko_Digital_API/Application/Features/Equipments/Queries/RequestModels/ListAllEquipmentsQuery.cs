using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Queries.RequestModels
{
    public class ListAllEquipmentsQuery : IRequest<IReadOnlyList<Equipment>>
    {
        public ListAllEquipmentsQuery()
        {
        }
    }
}