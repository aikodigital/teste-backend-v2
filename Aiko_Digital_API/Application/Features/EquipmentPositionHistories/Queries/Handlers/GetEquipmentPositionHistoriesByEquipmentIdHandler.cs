using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentPositionHistories.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Queries.Handlers
{
    public class GetEquipmentPositionHistoriesByEquipmentIdHandler : 
        IRequestHandler<GetEquipmentPositionHistoriesByEquipmentIdQuery, 
            IReadOnlyList<EquipmentPositionHistory>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEquipmentPositionHistoriesByEquipmentIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IReadOnlyList<EquipmentPositionHistory>> 
            Handle(GetEquipmentPositionHistoriesByEquipmentIdQuery request, 
                CancellationToken cancellationToken)
        {
            var specEquipment = new EquipmentSpecification(request.EquipmentId);
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(specEquipment);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var spec = new EquipmentPositionHistorySpecification(request.EquipmentId);

            var equipmentPositionHistory =
                await _unitOfWork.Repository<EquipmentPositionHistory>().ListAllWithSpecAsync(spec);

            return equipmentPositionHistory;
        }
    }
}