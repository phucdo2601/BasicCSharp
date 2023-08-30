using System;
using System.Linq;
using System.Linq.Expressions;

namespace SalaryManagement.Infrastructure
{
    public interface IRepositoryBase<T>
    {
        T Find(string id);
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindIncludeByCondition(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        IQueryable<T> FindInclude(params Expression<Func<T, object>>[] includes);
        void RemoveRange(IQueryable<T> query);
        void Remove(T entity);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
