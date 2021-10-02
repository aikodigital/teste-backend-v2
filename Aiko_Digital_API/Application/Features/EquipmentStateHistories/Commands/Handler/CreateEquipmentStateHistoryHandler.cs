using System;
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
    public class CreateEquipmentStateHistoryHandler : 
        IRequestHandler<CreateEquipmentStateHistoryCommand, 
            EquipmentStateHistory>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEquipmentStateHistoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<EquipmentStateHistory> Handle(CreateEquipmentStateHistoryCommand request, CancellationToken cancellationToken)
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

            var equipmentStateHistory = new EquipmentStateHistory
            {
                EquipmentState = equipmentState,
                Equipment = equipment,
                Date = DateTime.Now
            };
            
            _unitOfWork.Repository<EquipmentStateHistory>().AddAsync(equipmentStateHistory);
            
            var result = await _unitOfWork.Complete();

            if(result <= 0)
                throw new WebException("Fail to create Equipment State History",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);

            return equipmentStateHistory;
        }
    }
}