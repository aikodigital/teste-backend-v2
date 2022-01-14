using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Data.Context;

using Domain.Interfaces.Repositories;
using Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ModelStateHourlyEarningsRepository : Repository<ModelStateHourlyEarnings>, IModelStateHourlyEarningsRepository
    {
        public ModelStateHourlyEarningsRepository(ApplicationDbContext db) : base(db) { }
        
        public async Task<IEnumerable<ModelStateHourlyEarnings>> GetEarningsByModel(Guid modelId)
        {
            return await Db.ModelStateHourlyEarnings.Where(e => e.ModelId == modelId).ToListAsync();
        }

        public void RemoveHourlyEarnings(IEnumerable<ModelStateHourlyEarnings> modelStateHourlyEarnings)
        {
            Db.ModelStateHourlyEarnings.RemoveRange(modelStateHourlyEarnings);
        }
    }
}