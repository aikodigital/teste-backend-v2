using System;

using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class StateHistoryService : IStateHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StateHistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Create(StateHistory stateHistory)
        {
            _unitOfWork.StateHistoryRepository.Add(stateHistory);
            return _unitOfWork.Commit();
        }

        public bool DeleteStateHistory(Guid id)
        {
            var stateHistory = _unitOfWork.StateHistoryRepository.GetStateHistory(id).Result;
            if (stateHistory is null) return false;
            
            _unitOfWork.StateHistoryRepository.RemoveStateHistory(stateHistory);
            return _unitOfWork.Commit();
        }
    }
}