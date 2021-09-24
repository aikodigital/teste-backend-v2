using Application.DTOs;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IHistoricoPosicaoEquipamentoService
    {
        Task<Response<List<HistoricoPosicaoEquipamentoDTO>>> GetAllAsync();

        Task<Response<HistoricoPosicaoEquipamentoDTO>> GetByIdAsync(Guid id);

        Task<Response<Guid>> RegisterAsync(HistoricoPosicaoEquipamentoDTO dto);

        Task<Response<Guid>> UpdateAsync(HistoricoPosicaoEquipamentoDTO dto);

        Task<Response<Guid>> RemoveAsync(Guid id);
    }
}
