using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.Equipments.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Queries.Handlers
{
    public class GetEquipmentByIdHandler : IRequestHandler<GetEquipmentByIdQuery, EquipmentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEquipmentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<EquipmentDto> Handle(GetEquipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification(request.EquipmentId);
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(spec);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            return _mapper.Map<Equipment,EquipmentDto>(equipment);
        }
    }
}