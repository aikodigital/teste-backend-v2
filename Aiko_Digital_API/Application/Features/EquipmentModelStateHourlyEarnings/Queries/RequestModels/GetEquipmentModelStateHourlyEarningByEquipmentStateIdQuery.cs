using System;
using System.Collections.Generic;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Queries.RequestModels
{
    public class GetEquipmentModelStateHourlyEarningByEquipmentStateIdQuery 
        : IRequest<IReadOnlyList<EquipmentModelStateHourlyEarningDto>>
    {
        public Guid EquipmentStateId { get; set; }
    }
}