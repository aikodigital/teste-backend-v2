using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IGanhosHoraEstadoRepository : 
        IGenericRepositoryAsync<Equipment_model_state_hourly_earnings>
    {
        Task<int> GetQuantHorasOperando(Guid id);

        Task<int> GetQuantHorasManutencao(Guid id);
    }
}
