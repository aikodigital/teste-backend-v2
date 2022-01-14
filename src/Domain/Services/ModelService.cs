using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public bool Create(Model model)
        {
            _unitOfWork.ModelRepository.Add(model);
            return _unitOfWork.Commit();
        }

        public bool Update(Model model)
        {
            _unitOfWork.ModelRepository.Update(model);
            return _unitOfWork.Commit();
        }

        public bool Remove(Model model)
        {
            _unitOfWork.ModelRepository.Remove(model);
            return _unitOfWork.Commit();
        }
    }
}