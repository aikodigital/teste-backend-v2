using App.ViewModels;

using AutoMapper;

using Domain.Models;

namespace App.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Equipment, EquipmentViewModel>().ReverseMap();
            CreateMap<Model, ModelViewModel>().ReverseMap();
            CreateMap<State, StateViewModel>().ReverseMap();
            CreateMap<PositionHistory, PositionHistoryViewModel>().ReverseMap();
            CreateMap<StateHistory, StateHistoryViewModel>().ReverseMap();
            CreateMap<ModelStateHourlyEarnings, ModelStateHourlyEarningViewModel>().ReverseMap();
        }
    }
}