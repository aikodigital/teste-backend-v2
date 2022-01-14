using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        public void Remove(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
    }
}