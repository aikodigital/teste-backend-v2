using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DatabaseContext _context { get; }

        public RepositoryBase(DatabaseContext context) => _context = context;

        public IQueryable<T> ReadAll() => _context.Set<T>().AsNoTracking();

        public IQueryable<T> ReadByCondition(Expression<Func<T, bool>> expression) =>
            _context.Set<T>().Where(expression).AsNoTracking();

        public async Task<T> Create(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            await _context.Entry(entity).ReloadAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            await _context.Entry(entity).ReloadAsync();
            return entity;
        }

        public async Task<bool> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync().Result > 0; 
        }
    }
}