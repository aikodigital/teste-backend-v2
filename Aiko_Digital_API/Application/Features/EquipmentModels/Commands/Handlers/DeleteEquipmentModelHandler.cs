using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentModels.Commands.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModels.Commands.Handlers
{
    public class DeleteEquipmentModelHandler : IRequestHandler<DeleteEquipmentModelCommand, EquipmentModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEquipmentModelHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<EquipmentModel> Handle(DeleteEquipmentModelCommand request, CancellationToken cancellationToken)
        {
            var equipmentModel = await _unitOfWork.Repository<EquipmentModel>()
                .GetByIdAsync(request.EquipmentModelId);
            
            if (equipmentModel == null)
                throw new WebException("Equipment Model not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            _unitOfWork.Repository<EquipmentModel>().Delete(equipmentModel);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
                throw new WebException("Fail to delete a Equipment Model",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);
            
            return equipmentModel;
        }
    }
}