using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class StateService : IStateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public bool Create(State state)
        {
            _unitOfWork.StateRepository.Add(state);
            return _unitOfWork.Commit();
        }

        public bool Update(State state)
        {
            _unitOfWork.StateRepository.Update(state);
            return _unitOfWork.Commit();
        }

        public bool Remove(State state)
        {
            _unitOfWork.StateRepository.Remove(state);
            return _unitOfWork.Commit();
        }
    }
}