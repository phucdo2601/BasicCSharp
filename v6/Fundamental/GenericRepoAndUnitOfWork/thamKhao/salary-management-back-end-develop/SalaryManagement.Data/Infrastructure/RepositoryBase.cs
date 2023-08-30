using Microsoft.EntityFrameworkCore;
using SalaryManagement.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SalaryManagement.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public SalaryConfirmContext RepositoryContext { get; set; }

        public RepositoryBase(SalaryConfirmContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public T Find(string id)
        {
            return RepositoryContext.Set<T>().Find(id);
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().AsNoTracking().Where(expression);
        }

        public IQueryable<T> FindIncludeByCondition(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = RepositoryContext.Set<T>().AsNoTracking().Where(expression);
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public IQueryable<T> FindInclude(params Expression<Func<T, object>>[] includes)
        {
            var query = RepositoryContext.Set<T>().AsNoTracking();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public void RemoveRange(IQueryable<T> query)
        {
            RepositoryContext.Set<T>().RemoveRange(query);
        }

        public void Remove(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Entry(entity).State = EntityState.Detached;
            RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
