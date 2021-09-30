using System;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Queries.RequestModels
{
    public class GetEquipmentByIdQuery : IRequest<Equipment>
    {
        public Guid EquipmentId { get; set; }
    }
}