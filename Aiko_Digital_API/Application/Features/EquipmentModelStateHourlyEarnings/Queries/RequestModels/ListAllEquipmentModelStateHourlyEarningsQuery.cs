using System.Collections.Generic;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Queries.RequestModels
{
    public class ListAllEquipmentModelStateHourlyEarningsQuery : 
        IRequest<IReadOnlyList<EquipmentModelStateHourlyEarningDto>>
    {
    }
}