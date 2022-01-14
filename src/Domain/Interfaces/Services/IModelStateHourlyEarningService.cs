using System;

using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IModelStateHourlyEarningService
    {
        bool Create(ModelStateHourlyEarnings modelStateHourlyEarnings);
        bool DeleteHourlyEarningsByModel(Guid id);
    }
}