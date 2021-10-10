using System.Collections.Generic;
using System.Net;
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
    public class GetEquipmentPositionHistoriesByEquipmentIdHandler : 
        IRequestHandler<GetEquipmentPositionHistoriesByEquipmentIdQuery, 
            IReadOnlyList<EquipmentPositionHistoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEquipmentPositionHistoriesByEquipmentIdHandler(IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyList<EquipmentPositionHistoryDto>> 
            Handle(GetEquipmentPositionHistoriesByEquipmentIdQuery request, 
                CancellationToken cancellationToken)
        {
            var specEquipment = new EquipmentSpecification(request.EquipmentId);
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(specEquipment);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var spec = new EquipmentPositionHistorySpecification(request.EquipmentId);

            var equipmentPositionHistory =
                await _unitOfWork.Repository<EquipmentPositionHistory>().ListAllWithSpecAsync(spec);

            return _mapper.Map<IReadOnlyList<EquipmentPositionHistory>,
                IReadOnlyList<EquipmentPositionHistoryDto>>(equipmentPositionHistory);
        }
    }
}