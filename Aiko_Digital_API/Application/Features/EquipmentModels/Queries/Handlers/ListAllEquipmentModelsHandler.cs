using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentModels.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModels.Queries.Handlers
{
    public class ListAllEquipmentModelsHandler : IRequestHandler<ListAllEquipmentModelsQuery, IReadOnlyList<EquipmentModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListAllEquipmentModelsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IReadOnlyList<EquipmentModel>> Handle(ListAllEquipmentModelsQuery request, CancellationToken cancellationToken)
        {
            var spec = new EquipmentModelSpecification();
            
            return await _unitOfWork.Repository<EquipmentModel>().ListAllWithSpecAsync(spec);
        }
    }
}