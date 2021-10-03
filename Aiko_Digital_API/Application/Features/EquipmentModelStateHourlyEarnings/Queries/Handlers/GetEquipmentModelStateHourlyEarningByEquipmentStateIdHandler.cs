using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.EquipmentModelStateHourlyEarnings.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Queries.Handlers
{
    public class GetEquipmentModelStateHourlyEarningByEquipmentStateIdHandler 
        : IRequestHandler<GetEquipmentModelStateHourlyEarningByEquipmentStateIdQuery, 
            IReadOnlyList<EquipmentModelStateHourlyEarningDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEquipmentModelStateHourlyEarningByEquipmentStateIdHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        
        public async Task<IReadOnlyList<EquipmentModelStateHourlyEarningDto>> 
            Handle(GetEquipmentModelStateHourlyEarningByEquipmentStateIdQuery request, 
                CancellationToken cancellationToken)
        {
            var equipmentState = await _unitOfWork.Repository<EquipmentState>()
                .GetByIdAsync(request.EquipmentStateId);
            
            if (equipmentState == null)
                throw new WebException("Equipment state not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var spec = new EquipmentModelStateHourlyEarningsSpecification(request.EquipmentStateId,true);
            var equipmentModelStateHourlyEarnings = await _unitOfWork.
                Repository<EquipmentModelStateHourlyEarning>()
                .ListAllWithSpecAsync(spec);

            return _mapper.Map<IReadOnlyList<EquipmentModelStateHourlyEarning>,
                IReadOnlyList<EquipmentModelStateHourlyEarningDto>>(equipmentModelStateHourlyEarnings);
        }
    }
}