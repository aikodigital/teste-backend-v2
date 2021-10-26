using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace Entities.Map
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<EquipmentDTO, Equipment>();

            CreateMap<Equipment, EquipmentDTO>()
                .ForMember(x => x.Id, x => x.MapFrom(x => x.Id))
                .ForMember(x => x.Name, x => x.MapFrom(x => x.Name))
                .ForMember(x => x.EquipmentModelId, x => x.MapFrom(x => x.EquipmentModelId))
                .ForMember(x => x.EquipmentModel, x => x.MapFrom(x => x.EquipmentModel));

            CreateMap<EquipmentModelDTO, EquipmentModel>().ReverseMap();

            CreateMap<EquipmentModelStateHourlyEarningsDTO, EquipmentModelStateHourlyEarnings>().ReverseMap();

            CreateMap<EquipmentStateDTO, EquipmentState>().ReverseMap();

            CreateMap<EquipmentStateHistoryDTO, EquipmentStateHistory>();
            CreateMap<EquipmentStateHistory, EquipmentStateHistoryDTO>()
                .ForMember(x => x.EquipmentId, opt => opt.MapFrom(x => x.EquipmentId))
                .ForMember(x => x.EquipmentStateId, opt => opt.MapFrom(x => x.EquipmentStateId))
                .ForMember(x => x.Equipment, opt => opt.MapFrom(x => x.Equipment))
                .ForMember(x => x.EquipmentState, opt => opt.MapFrom(x => x.EquipmentState));

            CreateMap<EquipmentPositionHistoryDTO, EquipmentPositionHistory>().ReverseMap();
        }
    }
}