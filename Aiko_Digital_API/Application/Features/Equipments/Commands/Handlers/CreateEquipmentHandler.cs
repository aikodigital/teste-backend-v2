using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.Equipments.Commands.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Commands.Handlers
{
    public class CreateEquipmentHandler : IRequestHandler<CreateEquipmentCommand, EquipmentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEquipmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<EquipmentDto> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var equipmentModel = await _unitOfWork.Repository<EquipmentModel>()
                .GetByIdAsync(request.EquipmentModelId);
            
            if (equipmentModel == null)
                throw new WebException("Equipment Model not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var spec = new EquipmentSpecification(request.Name);
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(spec);
            
            if (equipment != null)
                throw new WebException("Fail to create Equipment " +
                                       "because the equipment exists in database!",
                    (WebExceptionStatus) HttpStatusCode.Conflict);

            equipment = new Equipment
            {
                EquipmentModel = equipmentModel,
                Name = request.Name
            };
            
            _unitOfWork.Repository<Equipment>().AddAsync(equipment);
            
            var result = await _unitOfWork.Complete();

            if(result <= 0)
                throw new WebException("Fail to create Equipment",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);

            return _mapper.Map<Equipment,EquipmentDto>(equipment);
        }
    }
}