using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentModelStateHourlyEarnings.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Queries.Handlers
{
    public class GetEquipmentModelStateHourlyEarningByValueHandler 
        : IRequestHandler<GetEquipmentModelStateHourlyEarningByValueQuery, 
            IReadOnlyList<EquipmentModelStateHourlyEarning>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEquipmentModelStateHourlyEarningByValueHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IReadOnlyList<EquipmentModelStateHourlyEarning>> 
            Handle(GetEquipmentModelStateHourlyEarningByValueQuery request, 
                CancellationToken cancellationToken)
        {
            var spec = new EquipmentModelStateHourlyEarningsSpecification(request.Value);
            var equipmentModelStateHourlyEarnings = await _unitOfWork.
                Repository<EquipmentModelStateHourlyEarning>()
                .ListAllWithSpecAsync(spec);

            return equipmentModelStateHourlyEarnings;
        }
    }
}