using System;
using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Queries.RequestModels
{
    public class GetEquipmentModelStateHourlyEarningByEquipmentModelIdQuery 
        : IRequest<IReadOnlyList<EquipmentModelStateHourlyEarning>>
    {
        public Guid EquipmentModelId { get; set; }
    }
}