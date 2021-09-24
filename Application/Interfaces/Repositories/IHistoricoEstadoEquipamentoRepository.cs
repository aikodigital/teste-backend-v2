using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IHistoricoEstadoEquipamentoRepository
        : IGenericRepositoryAsync<Equipment_state_history>
    {
        Task<Equipment_state_history> GetEstadoAtualById(Guid id);

        Task<int> GetQuantHorasOperando(Guid id);

        Task<int> GetQuantHorasManutencao(Guid id);

        Task<int> GetQuantHorasOperandoHoje(Guid id);

        Task<int> GetQuantHorasHoje(Guid id);

    }
}
