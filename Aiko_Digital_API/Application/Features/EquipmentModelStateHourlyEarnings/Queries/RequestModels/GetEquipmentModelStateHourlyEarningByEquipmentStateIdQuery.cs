using System;
using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Queries.RequestModels
{
    public class GetEquipmentModelStateHourlyEarningByEquipmentStateIdQuery 
        : IRequest<IReadOnlyList<EquipmentModelStateHourlyEarning>>
    {
        public Guid EquipmentStateId { get; set; }
    }
}