using System;
using MediatR;

namespace Application.Features.Equipments.Queries.RequestModels
{
    public class GetEquipmentGainQuery : IRequest<float>
    {
        public Guid EquipmentId { get; set; }
        public DateTime Date { get; set; }
    }
}