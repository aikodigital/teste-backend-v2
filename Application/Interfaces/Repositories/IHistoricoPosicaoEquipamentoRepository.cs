using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IHistoricoPosicaoEquipamentoRepository 
        : IGenericRepositoryAsync<Equipment_position_history>
    {
        Task<Equipment_position_history> GetPosicaoAtualById(Guid id);
    }
}
