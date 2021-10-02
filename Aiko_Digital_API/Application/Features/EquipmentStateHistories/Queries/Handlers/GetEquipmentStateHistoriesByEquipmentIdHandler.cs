using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentPositionHistories.Queries.RequestModels;
using Application.Features.EquipmentStateHistories.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Queries.Handlers
{
    public class GetEquipmentStateHistoriesByEquipmentIdHandler 
        : IRequestHandler<GetEquipmentStateHistoriesByEquipmentIdQuery, 
            IReadOnlyList<EquipmentStateHistory>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEquipmentStateHistoriesByEquipmentIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IReadOnlyList<EquipmentStateHistory>> 
            Handle(GetEquipmentStateHistoriesByEquipmentIdQuery request, 
                CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification();
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(spec);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);

            var specEquipmentStateHistory = new EquipmentStateHistorySpecification(request.EquipmentId);

            return await _unitOfWork.Repository<EquipmentStateHistory>()
                .ListAllWithSpecAsync(specEquipmentStateHistory);
        }
    }
}