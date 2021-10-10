using Application.Dtos;
using AutoMapper;
using Domain;

namespace Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Equipment, EquipmentDto>()
                .ForMember(e => e.EquipmentModel, o => 
                    o.MapFrom(s => s.EquipmentModel.Name));
            
            CreateMap<EquipmentModelStateHourlyEarning, EquipmentModelStateHourlyEarningDto>()
                .ForMember(e => e.EquipmentModel, o =>
                    o.MapFrom(s => s.EquipmentModel.Name))
                .ForMember(e => e.EquipmentState, o =>
                    o.MapFrom(s => s.EquipmentState.Name));
            
            CreateMap<EquipmentPositionHistory, EquipmentPositionHistoryDto>()
                .ForMember(e => e.Equipment, o =>
                    o.MapFrom(s => s.Equipment.Name))
                .ForMember(e => e.EquipmentModel, o =>
                    o.MapFrom(s => s.Equipment.EquipmentModel.Name));
            
            CreateMap<EquipmentStateHistory, EquipmentStateHistoryDto>()
                .ForMember(e => e.Equipment, o =>
                    o.MapFrom(s => s.Equipment.Name))
                .ForMember(e => e.EquipmentState, o =>
                    o.MapFrom(s => s.EquipmentState.Name));
        }
    }
}