using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentPositionHistories.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Queries.Handlers
{
    public class ListAllEquipmentPositionHistoriesHandler : 
        IRequestHandler<ListAllEquipmentPositionHistoriesQuery, 
            IReadOnlyList<EquipmentPositionHistory>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListAllEquipmentPositionHistoriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IReadOnlyList<EquipmentPositionHistory>> 
            Handle(ListAllEquipmentPositionHistoriesQuery request, 
                CancellationToken cancellationToken)
        {
            var spec = new EquipmentPositionHistorySpecification();
            var equipmentPositionHistories =
                await _unitOfWork.Repository<EquipmentPositionHistory>().ListAllWithSpecAsync(spec);

            return equipmentPositionHistories;
        }
    }
}