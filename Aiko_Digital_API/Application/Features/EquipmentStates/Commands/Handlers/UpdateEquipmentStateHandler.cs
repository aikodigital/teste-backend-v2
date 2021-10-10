using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentStates.Commands.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStates.Commands.Handlers
{
    public class UpdateEquipmentStateHandler : IRequestHandler<UpdateEquipmentStateCommand, 
        EquipmentState>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEquipmentStateHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<EquipmentState> Handle(UpdateEquipmentStateCommand request, 
            CancellationToken cancellationToken)
        {
            var equipmentState = await _unitOfWork.Repository<EquipmentState>()
                .GetByIdAsync(request.EquipmentStateId);
            
            if (equipmentState == null)
                throw new WebException("Equipment State not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var spec = new EquipmentStateSpecification(request.EquipmentStateId, request.Name, 
                request.Color);
            var equipmentStateCheckNameColor = await _unitOfWork.Repository<EquipmentState>()
                .GetEntityWithSpecAsync(spec);
            
            if (equipmentStateCheckNameColor != null)
                throw new WebException("Fail to update Equipment State " +
                                       "because the equipment state exists in database!",
                    (WebExceptionStatus) HttpStatusCode.Conflict);

            equipmentState.Name = request.Name;
            equipmentState.Color = request.Color;
            
            _unitOfWork.Repository<EquipmentState>().Update(equipmentState);

            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
                throw new WebException("Fail in update Equipment State",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);

            return equipmentState;
        }
    }
}