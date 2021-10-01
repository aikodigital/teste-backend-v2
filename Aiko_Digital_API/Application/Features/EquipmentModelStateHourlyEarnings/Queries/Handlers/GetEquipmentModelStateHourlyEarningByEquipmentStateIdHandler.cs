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
    public class GetEquipmentModelStateHourlyEarningByEquipmentStateIdHandler 
        : IRequestHandler<GetEquipmentModelStateHourlyEarningByEquipmentStateIdQuery, 
            IReadOnlyList<EquipmentModelStateHourlyEarning>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEquipmentModelStateHourlyEarningByEquipmentStateIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        
        public async Task<IReadOnlyList<EquipmentModelStateHourlyEarning>> 
            Handle(GetEquipmentModelStateHourlyEarningByEquipmentStateIdQuery request, 
                CancellationToken cancellationToken)
        {
            var equipmentState = await _unitOfWork.Repository<EquipmentState>()
                .GetByIdAsync(request.EquipmentStateId);
            
            if (equipmentState == null)
                throw new WebException("Equipment state not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var spec = new EquipmentModelStateHourlyEarningsSpecification(request.EquipmentStateId,true);
            var equipmentModelStateHourlyEarnings = await _unitOfWork.
                Repository<EquipmentModelStateHourlyEarning>()
                .ListAllWithSpecAsync(spec);

            return equipmentModelStateHourlyEarnings;

        }
    }
}