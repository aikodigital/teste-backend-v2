using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IModelService
    {
        bool Create(Model model);
        bool Update(Model model);
        bool Remove(Model model);
    }
}