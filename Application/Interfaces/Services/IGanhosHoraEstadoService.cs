using Application.DTOs;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IGanhosHoraEstadoService
    {
        Task<Response<List<GanhoHoraEstadoDTO>>> GetAllAsync();

        Task<Response<GanhoHoraEstadoDTO>> GetByIdAsync(Guid id);

        Task<Response<Guid>> RegisterAsync(GanhoHoraEstadoDTO dto);

        Task<Response<Guid>> UpdateAsync(GanhoHoraEstadoDTO dto);

        Task<Response<Guid>> RemoveAsync(Guid id);
    }
}
