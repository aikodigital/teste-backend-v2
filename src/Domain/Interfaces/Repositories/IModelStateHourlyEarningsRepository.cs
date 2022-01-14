using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IModelStateHourlyEarningsRepository : IRepository<ModelStateHourlyEarnings>
    {
        Task<IEnumerable<ModelStateHourlyEarnings>> GetEarningsByModel(Guid modelId);
        void RemoveHourlyEarnings(IEnumerable<ModelStateHourlyEarnings> modelStateHourlyEarnings);
    }
}