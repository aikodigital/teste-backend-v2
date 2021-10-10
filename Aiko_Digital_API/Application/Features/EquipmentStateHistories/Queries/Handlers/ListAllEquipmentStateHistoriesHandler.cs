using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.EquipmentStateHistories.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Queries.Handlers
{
    public class ListAllEquipmentStateHistoriesHandler : 
        IRequestHandler<ListAllEquipmentStateHistoriesQuery, 
            IReadOnlyList<EquipmentStateHistoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListAllEquipmentStateHistoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyList<EquipmentStateHistoryDto>> Handle(ListAllEquipmentStateHistoriesQuery request, CancellationToken cancellationToken)
        {
            var spec = new EquipmentStateHistorySpecification();

            var equipmentStatesHistories = await _unitOfWork.Repository<EquipmentStateHistory>()
                .ListAllWithSpecAsync(spec);
            
            return _mapper.Map<IReadOnlyList<EquipmentStateHistory>, IReadOnlyList<EquipmentStateHistoryDto>>(
                equipmentStatesHistories);
        }
    }
}