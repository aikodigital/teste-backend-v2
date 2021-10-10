using System;
using MediatR;

namespace Application.Features.Equipments.Queries.RequestModels
{
    public class GetEquipmentProductivityPercentageQuery : IRequest<string>
    {
        public Guid EquipmentId { get; set; }
        public DateTime Date { get; set; }
    }
}