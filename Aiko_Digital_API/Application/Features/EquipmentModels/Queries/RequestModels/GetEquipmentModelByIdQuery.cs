using System;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModels.Queries.RequestModels
{
    public class GetEquipmentModelByIdQuery : IRequest<EquipmentModel>
    {
        public Guid EquipmentModelId { get; set; }
    }
}