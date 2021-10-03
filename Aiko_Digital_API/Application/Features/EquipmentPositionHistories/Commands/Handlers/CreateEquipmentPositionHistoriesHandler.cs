using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.EquipmentPositionHistories.Commands.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Commands.Handlers
{
    public class CreateEquipmentPositionHistoriesHandler : 
        IRequestHandler<CreateEquipmentPositionHistoriesCommand, 
        EquipmentPositionHistoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEquipmentPositionHistoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<EquipmentPositionHistoryDto> Handle(CreateEquipmentPositionHistoriesCommand request, 
            CancellationToken cancellationToken)
        {
            var specEquipment = new EquipmentSpecification(request.EquipmentId);
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(specEquipment);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);

            var spec = new EquipmentPositionHistorySpecification(request.EquipmentId, DateTime.Now,
                request.Lat, request.Lon);
            
            var equipmentPositionHistory = await _unitOfWork.Repository<EquipmentPositionHistory>()
                .GetEntityWithSpecAsync(spec);
            
            if (equipmentPositionHistory != null)
                throw new WebException("Equipment Position History exist in data base " +
                                       "for this date time!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            equipmentPositionHistory = new EquipmentPositionHistory
            {
                Equipment = equipment,
                Date = DateTime.Now,
                Lat = request.Lat,
                Lon = request.Lon
            };
            
            _unitOfWork.Repository<EquipmentPositionHistory>().AddAsync(equipmentPositionHistory);
            
            var result = await _unitOfWork.Complete();

            if(result <= 0)
                throw new WebException("Fail to create Equipment Position History",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);
            
            return _mapper.Map<EquipmentPositionHistory, EquipmentPositionHistoryDto>
                (equipmentPositionHistory);
        }
    }
}