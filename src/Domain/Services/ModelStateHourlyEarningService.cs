using System;

using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class ModelStateHourlyEarningService : IModelStateHourlyEarningService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelStateHourlyEarningService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Create(ModelStateHourlyEarnings modelStateHourlyEarnings)
        {
            _unitOfWork.ModelStateHourlyEarningsRepository.Add(modelStateHourlyEarnings);
            return _unitOfWork.Commit();
        }

        public bool DeleteHourlyEarningsByModel(Guid id)
        {
            var hourlyEarnings = _unitOfWork.ModelStateHourlyEarningsRepository.GetEarningsByModel(id).Result;
            if (hourlyEarnings is null) return false;
            
            _unitOfWork.ModelStateHourlyEarningsRepository.RemoveHourlyEarnings(hourlyEarnings);
            return _unitOfWork.Commit();
        }
    }
}