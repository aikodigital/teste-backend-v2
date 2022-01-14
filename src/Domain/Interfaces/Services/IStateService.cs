using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IStateService
    {
        bool Create(State state);
        bool Update(State state);
        bool Remove(State state);
    }
}