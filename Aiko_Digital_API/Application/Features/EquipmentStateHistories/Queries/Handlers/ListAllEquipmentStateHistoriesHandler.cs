using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentStateHistories.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Queries.Handlers
{
    public class ListAllEquipmentStateHistoriesHandler : 
        IRequestHandler<ListAllEquipmentStateHistoriesQuery, 
            IReadOnlyList<EquipmentStateHistory>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListAllEquipmentStateHistoriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        
        public async Task<IReadOnlyList<EquipmentStateHistory>> Handle(ListAllEquipmentStateHistoriesQuery request, CancellationToken cancellationToken)
        {
            var spec = new EquipmentStateHistorySpecification();

            return await _unitOfWork.Repository<EquipmentStateHistory>()
                .ListAllWithSpecAsync(spec);
        }
    }
}