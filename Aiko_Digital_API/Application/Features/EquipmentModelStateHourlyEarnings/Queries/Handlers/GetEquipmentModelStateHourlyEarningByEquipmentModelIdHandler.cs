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
    public class GetEquipmentModelStateHourlyEarningByEquipmentModelIdHandler 
        : IRequestHandler<GetEquipmentModelStateHourlyEarningByEquipmentModelIdQuery, 
            IReadOnlyList<EquipmentModelStateHourlyEarningDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEquipmentModelStateHourlyEarningByEquipmentModelIdHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyList<EquipmentModelStateHourlyEarningDto>> 
            Handle(GetEquipmentModelStateHourlyEarningByEquipmentModelIdQuery request, 
                CancellationToken cancellationToken)
        {
            var equipmentModel = await _unitOfWork.Repository<EquipmentModel>()
                .GetByIdAsync(request.EquipmentModelId);
            
            if (equipmentModel == null)
                throw new WebException("Equipment Model not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var spec = new EquipmentModelStateHourlyEarningsSpecification(request.EquipmentModelId);
            var equipmentModelStateHourlyEarnings = await _unitOfWork.
                Repository<EquipmentModelStateHourlyEarning>()
                .ListAllWithSpecAsync(spec);

            return _mapper.Map<IReadOnlyList<EquipmentModelStateHourlyEarning>,
                IReadOnlyList<EquipmentModelStateHourlyEarningDto>>(equipmentModelStateHourlyEarnings);
        }
    }
}