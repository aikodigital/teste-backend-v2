using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Queries.RequestModels
{
    public class ListAllEquipmentModelStateHourlyEarningsQuery : 
        IRequest<IReadOnlyList<EquipmentModelStateHourlyEarning>>
    {
    }
}