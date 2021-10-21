using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> ReadAll();
        
        IQueryable<T> ReadByCondition(Expression<Func<T, bool>> expression);
        
        Task<T> Create(T entity);
        
        Task<T> Update(T entity);
        
        Task<bool> Delete(T entity);
    }
}