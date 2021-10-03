using System;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Queries.RequestModels
{
    public class GetEquipmentByIdQuery : IRequest<EquipmentDto>
    {
        public Guid EquipmentId { get; set; }
    }
}