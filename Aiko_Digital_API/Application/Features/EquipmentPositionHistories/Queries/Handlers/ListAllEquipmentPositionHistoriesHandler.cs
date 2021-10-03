using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.EquipmentPositionHistories.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Queries.Handlers
{
    public class ListAllEquipmentPositionHistoriesHandler : 
        IRequestHandler<ListAllEquipmentPositionHistoriesQuery, 
            IReadOnlyList<EquipmentPositionHistoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListAllEquipmentPositionHistoriesHandler(IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyList<EquipmentPositionHistoryDto>> 
            Handle(ListAllEquipmentPositionHistoriesQuery request, 
                CancellationToken cancellationToken)
        {
            var spec = new EquipmentPositionHistorySpecification();
            var equipmentPositionHistories =
                await _unitOfWork.Repository<EquipmentPositionHistory>().ListAllWithSpecAsync(spec);

            return _mapper.Map<IReadOnlyList<EquipmentPositionHistory>,
                IReadOnlyList<EquipmentPositionHistoryDto>>(equipmentPositionHistories);
        }
    }
}