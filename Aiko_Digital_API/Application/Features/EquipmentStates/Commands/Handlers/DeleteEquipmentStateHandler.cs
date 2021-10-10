using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentStates.Commands.RequestModels;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStates.Commands.Handlers
{
    public class DeleteEquipmentStateHandler : IRequestHandler<DeleteEquipmentStateCommand, EquipmentState>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEquipmentStateHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<EquipmentState> Handle(DeleteEquipmentStateCommand request, CancellationToken cancellationToken)
        {
            var equipmentState = await _unitOfWork.Repository<EquipmentState>()
                .GetByIdAsync(request.EquipmentStateId);
            
            if (equipmentState == null)
                throw new WebException("Equipment State not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            _unitOfWork.Repository<EquipmentState>().Delete(equipmentState);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
                throw new WebException("Fail to delete a Equipment State",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);

            return equipmentState;
        }
    }
}