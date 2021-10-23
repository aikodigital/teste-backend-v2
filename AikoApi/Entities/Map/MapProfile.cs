using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace Entities.Map
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<EquipmentDTO, Equipment>().ReverseMap();

            CreateMap<EquipmentModelDTO, EquipmentModel>().ReverseMap();

            CreateMap<EquipmentModelStateHourlyEarningsDTO, EquipmentModelStateHourlyEarnings>().ReverseMap();

            CreateMap<EquipmentStateDTO, EquipmentState>().ReverseMap();

            CreateMap<EquipmentStateHistoryDTO, EquipmentStateHistory>().ReverseMap();

            CreateMap<EquipmentPositionHistoryDTO, EquipmentPositionHistory>().ReverseMap();
        }
    }
}