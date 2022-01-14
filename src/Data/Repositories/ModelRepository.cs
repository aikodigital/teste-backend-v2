using Data.Context;

using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Data.Repositories
{
    public class ModelRepository : Repository<Model>, IModelRepository
    {
        public ModelRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}