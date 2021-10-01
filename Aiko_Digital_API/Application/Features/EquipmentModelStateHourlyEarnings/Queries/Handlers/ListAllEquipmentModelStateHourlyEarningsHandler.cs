using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentModelStateHourlyEarnings.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Queries.Handlers
{
    public class ListAllEquipmentModelStateHourlyEarningsHandler : 
        IRequestHandler<ListAllEquipmentModelStateHourlyEarningsQuery, 
            IReadOnlyList<EquipmentModelStateHourlyEarning>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListAllEquipmentModelStateHourlyEarningsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IReadOnlyList<EquipmentModelStateHourlyEarning>> 
            Handle(ListAllEquipmentModelStateHourlyEarningsQuery request, 
                CancellationToken cancellationToken)
        {
            var spec = new EquipmentModelStateHourlyEarningsSpecification();

            return await _unitOfWork.Repository<EquipmentModelStateHourlyEarning>().ListAllWithSpecAsync(spec);
        }
    }
}