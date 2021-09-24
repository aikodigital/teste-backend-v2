using Application.DTOs;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IEquipamentoService
    {
        Task<Response<List<EquipamentoDTO>>> GetAllAsync();

        Task<Response<EquipamentoDTO>> GetByIdAsync(Guid id);

        Task<Response<Guid>> RegisterAsync(EquipamentoDTO dto);

        Task<Response<Guid>> UpdateAsync(EquipamentoDTO dto);

        Task<Response<Guid>> RemoveAsync(Guid id);

        Task<Response<HistoricoPosicaoEquipamentoDTO>> GetPosicaoAtualById(Guid id);

        Task<Response<HistoricoEstadoEquipamentoDTO>> GetEstadoAtualById(Guid id);

        Task<Response<int>> GetGanhoByEquipamentoById(Guid id);

        Task<Response<string>> GetProdutividadeByEquipamentoById(Guid id);
    }
}
