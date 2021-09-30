using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentModels.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModels.Queries.Handlers
{
    public class GetEquipmentModelByIdHandler : IRequestHandler<GetEquipmentModelByIdQuery, EquipmentModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEquipmentModelByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<EquipmentModel> Handle(GetEquipmentModelByIdQuery request, CancellationToken cancellationToken)
        {

            var equipmentModel = await _unitOfWork.Repository<EquipmentModel>()
                .GetByIdAsync(request.EquipmentModelId);
            
            if (equipmentModel == null)
                throw new WebException("Equipment Model not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            return equipmentModel;
        }
    }
}