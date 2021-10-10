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
    public class UpdateEquipmentModelHandler : IRequestHandler<UpdateEquipmentModelCommand, EquipmentModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEquipmentModelHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<EquipmentModel> Handle(UpdateEquipmentModelCommand request, CancellationToken cancellationToken)
        {
            var equipmentModel = await _unitOfWork.Repository<EquipmentModel>()
                .GetByIdAsync(request.EquipmentModelId);
            
            if (equipmentModel == null)
                throw new WebException("Equipment Model not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var spec = new EquipmentModelSpecification(request.Name);
            var equipmentModelCheckName = await _unitOfWork.Repository<EquipmentModel>()
                .GetEntityWithSpecAsync(spec);

            if (equipmentModelCheckName != null)
                throw new WebException("Fail to create Equipment Model " +
                                       "because the equipment model exists in database!",
                    (WebExceptionStatus) HttpStatusCode.Conflict);
            
            equipmentModel.Name = request.Name;
            
            _unitOfWork.Repository<EquipmentModel>().Update(equipmentModel);

            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
                throw new WebException("Fail in update Equipment Model",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);

            return equipmentModel;
            
        }
    }
}