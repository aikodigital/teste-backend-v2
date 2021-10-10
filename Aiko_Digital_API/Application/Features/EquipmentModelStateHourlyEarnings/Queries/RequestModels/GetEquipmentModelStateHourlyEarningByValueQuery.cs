using System.Collections.Generic;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Queries.RequestModels
{
    public class GetEquipmentModelStateHourlyEarningByValueQuery 
        : IRequest<IReadOnlyList<EquipmentModelStateHourlyEarningDto>>
    {
        public float Value { get; set; }
    }
}