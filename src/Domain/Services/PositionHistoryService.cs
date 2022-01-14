using System;
using System.Threading.Tasks;

using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class PositionHistoryService : IPositionHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PositionHistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public bool Create(PositionHistory positionHistory)
        {
            _unitOfWork.PositionHistoryRepository.Add(positionHistory);
            return _unitOfWork.Commit();
        }

        public bool DeletePositionHistory(Guid id)
        {
            var positionHistory = _unitOfWork.PositionHistoryRepository.GetPositionHistory(id).Result;
            if (positionHistory is null) return false;
            
            _unitOfWork.PositionHistoryRepository.RemovePositionHistory(positionHistory);
            return _unitOfWork.Commit();
        }
    }
}