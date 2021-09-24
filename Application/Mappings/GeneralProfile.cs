using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<EquipamentoDTO, Equipment>().ReverseMap();
            CreateMap<ModelEquipamentoDTO, Equipment_Model>().ReverseMap();
            CreateMap<EstadoEquipamentoDTO, Equipment_State>().ReverseMap();
            CreateMap<GanhoHoraEstadoDTO, Equipment_model_state_hourly_earnings>().ReverseMap();
            CreateMap<HistoricoPosicaoEquipamentoDTO, Equipment_position_history>().ReverseMap();
            CreateMap<HistoricoEstadoEquipamentoDTO, Equipment_state_history>().ReverseMap();
        }
    }
}
