using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.EquipmentPositionHistories.Queries.RequestModels;
using Application.Features.EquipmentStateHistories.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Queries.Handlers
{
    public class GetEquipmentStateHistoriesByEquipmentIdHandler 
        : IRequestHandler<GetEquipmentStateHistoriesByEquipmentIdQuery, 
            IReadOnlyList<EquipmentStateHistoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEquipmentStateHistoriesByEquipmentIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyList<EquipmentStateHistoryDto>> 
            Handle(GetEquipmentStateHistoriesByEquipmentIdQuery request, 
                CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification(request.EquipmentId);
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(spec);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);

            var specEquipmentStateHistory = new EquipmentStateHistorySpecification(request.EquipmentId,false);

            var equipmentStatesHistories = await _unitOfWork.Repository<EquipmentStateHistory>()
                .ListAllWithSpecAsync(specEquipmentStateHistory);

            return _mapper.Map<IReadOnlyList<EquipmentStateHistory>, IReadOnlyList<EquipmentStateHistoryDto>>(
                equipmentStatesHistories);
        }
    }
}