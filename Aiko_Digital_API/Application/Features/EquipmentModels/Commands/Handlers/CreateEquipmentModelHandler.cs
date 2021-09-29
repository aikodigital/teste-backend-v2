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
    public class CreateEquipmentModelHandler : IRequestHandler<CreateEquipmentModelCommand, EquipmentModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEquipmentModelHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<EquipmentModel> Handle(CreateEquipmentModelCommand request, CancellationToken cancellationToken)
        {
            var spec = new EquipmentModelSpecification(request.Name);

            var equipmentModel = await _unitOfWork.Repository<EquipmentModel>().GetEntityWithSpec(spec);

            if (equipmentModel != null)
                throw new WebException("Fail to create Equipment Model because the equipment exists in database!",
                    (WebExceptionStatus) HttpStatusCode.Conflict);

            equipmentModel = new EquipmentModel {Name = request.Name};
            
            _unitOfWork.Repository<EquipmentModel>().AddAsync(equipmentModel);

            var result = await _unitOfWork.Complete();

            if(result <= 0)
                throw new WebException("Fail to create Equipment Model",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);
            
            return equipmentModel;
        }
    }
}