using System.Collections.Generic;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Queries.RequestModels
{
    public class ListAllEquipmentsQuery : IRequest<IReadOnlyList<EquipmentDto>>
    {
        public ListAllEquipmentsQuery()
        {
        }
    }
}