using Application.DTOs;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IEstadoEquipamentoService
    {
        Task<Response<List<EstadoEquipamentoDTO>>> GetAllAsync();

        Task<Response<EstadoEquipamentoDTO>> GetByIdAsync(int id);

        Task<Response<int>> RegisterAsync(EstadoEquipamentoDTO dto);

        Task<Response<int>> UpdateAsync(EstadoEquipamentoDTO dto);

        Task<Response<int>> RemoveAsync(int id);
    }
}
