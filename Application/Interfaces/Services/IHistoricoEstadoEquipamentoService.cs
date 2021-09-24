using Application.DTOs;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IHistoricoEstadoEquipamentoService
    {
        Task<Response<List<HistoricoEstadoEquipamentoDTO>>> GetAllAsync();

        Task<Response<HistoricoEstadoEquipamentoDTO>> GetByIdAsync(Guid id);

        Task<Response<Guid>> RegisterAsync(HistoricoEstadoEquipamentoDTO dto);

        Task<Response<Guid>> UpdateAsync(HistoricoEstadoEquipamentoDTO dto);

        Task<Response<Guid>> RemoveAsync(Guid id);
    }
}
