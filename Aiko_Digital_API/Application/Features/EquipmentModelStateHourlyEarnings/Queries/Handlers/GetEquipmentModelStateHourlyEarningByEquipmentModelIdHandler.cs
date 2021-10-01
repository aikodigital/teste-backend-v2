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
    public class GetEquipmentModelStateHourlyEarningByEquipmentModelIdHandler 
        : IRequestHandler<GetEquipmentModelStateHourlyEarningByEquipmentModelIdQuery, 
            IReadOnlyList<EquipmentModelStateHourlyEarning>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEquipmentModelStateHourlyEarningByEquipmentModelIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IReadOnlyList<EquipmentModelStateHourlyEarning>> 
            Handle(GetEquipmentModelStateHourlyEarningByEquipmentModelIdQuery request, 
                CancellationToken cancellationToken)
        {
            var equipmentModel = await _unitOfWork.Repository<EquipmentModel>()
                .GetByIdAsync(request.EquipmentModelId);
            
            if (equipmentModel == null)
                throw new WebException("Equipment Model not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var spec = new EquipmentModelStateHourlyEarningsSpecification(request.EquipmentModelId);
            var equipmentModelStateHourlyEarnings = await _unitOfWork.
                Repository<EquipmentModelStateHourlyEarning>()
                .ListAllWithSpecAsync(spec);

            return equipmentModelStateHourlyEarnings;
        }
    }
}