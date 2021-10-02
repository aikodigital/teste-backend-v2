using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentStateHistories.Commands.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Commands.Handler
{
    public class UpdateEquipmentStateHistoryHandler : 
        IRequestHandler<UpdateEquipmentStateHistoryCommand, 
            EquipmentStateHistory>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEquipmentStateHistoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<EquipmentStateHistory> 
            Handle(UpdateEquipmentStateHistoryCommand request, 
                CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification();
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(spec);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var equipmentState = await _unitOfWork.Repository<EquipmentState>()
                .GetByIdAsync(request.EquipmentStateId);
            
            if (equipmentState == null)
                throw new WebException("Equipment state not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);

            var specEquipmentStateHistory = new EquipmentStateHistorySpecification
                (request.EquipmentId, request.Date);

            var equipmentStateHistory = await _unitOfWork.Repository<EquipmentStateHistory>()
                .GetEntityWithSpecAsync(specEquipmentStateHistory);
            
            if (equipmentStateHistory == null)
                throw new WebException("Equipment State History not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);

            equipmentStateHistory.EquipmentState = equipmentState;
            
            _unitOfWork.Repository<EquipmentStateHistory>().Update(equipmentStateHistory);

            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
                throw new WebException("Fail in update Equipment State History",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);

            return equipmentStateHistory;
        }
    }
}