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
    public class GetEquipmentModelStateHourlyEarningByValueHandler 
        : IRequestHandler<GetEquipmentModelStateHourlyEarningByValueQuery, 
            IReadOnlyList<EquipmentModelStateHourlyEarningDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEquipmentModelStateHourlyEarningByValueHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyList<EquipmentModelStateHourlyEarningDto>> 
            Handle(GetEquipmentModelStateHourlyEarningByValueQuery request, 
                CancellationToken cancellationToken)
        {
            var spec = new EquipmentModelStateHourlyEarningsSpecification(request.Value);
            var equipmentModelStateHourlyEarnings = await _unitOfWork.
                Repository<EquipmentModelStateHourlyEarning>()
                .ListAllWithSpecAsync(spec);

            return _mapper.Map<IReadOnlyList<EquipmentModelStateHourlyEarning>,
                IReadOnlyList<EquipmentModelStateHourlyEarningDto>>(equipmentModelStateHourlyEarnings);
        }
    }
}