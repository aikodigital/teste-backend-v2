using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Queries.RequestModels
{
    public class GetEquipmentModelStateHourlyEarningByValueQuery 
        : IRequest<IReadOnlyList<EquipmentModelStateHourlyEarning>>
    {
        public float Value { get; set; }
    }
}