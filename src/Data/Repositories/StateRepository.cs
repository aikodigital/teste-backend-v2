using Data.Context;

using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Data.Repositories
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}