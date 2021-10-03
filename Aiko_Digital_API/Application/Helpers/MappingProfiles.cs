using Application.Dtos;
using AutoMapper;
using Domain;

namespace Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<EquipmentModelStateHourlyEarning, EquipmentModelStateHourlyEarningDto>();
            CreateMap<EquipmentPositionHistory, EquipmentPositionHistoryDto>();
            CreateMap<EquipmentStateHistory, EquipmentStateHistoryDto>();
        }
    }
}