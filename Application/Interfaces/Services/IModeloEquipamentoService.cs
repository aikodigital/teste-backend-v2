using Application.DTOs;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IModeloEquipamentoService
    {
        Task<Response<List<ModelEquipamentoDTO>>> GetAllAsync();

        Task<Response<ModelEquipamentoDTO>> GetByIdAsync(Guid id);

        Task<Response<Guid>> RegisterAsync(ModelEquipamentoDTO dto);

        Task<Response<Guid>> UpdateAsync(ModelEquipamentoDTO dto);

        Task<Response<Guid>> RemoveAsync(Guid id);
    }
}
