using System;
using System.Collections.Generic;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Queries.RequestModels
{
    public class GetEquipmentModelStateHourlyEarningByEquipmentModelIdQuery 
        : IRequest<IReadOnlyList<EquipmentModelStateHourlyEarningDto>>
    {
        public Guid EquipmentModelId { get; set; }
    }
}