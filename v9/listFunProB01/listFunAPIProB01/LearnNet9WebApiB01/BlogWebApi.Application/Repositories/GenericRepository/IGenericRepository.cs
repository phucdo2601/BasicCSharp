using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Application.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        T FindById(Guid id);

        IEnumerable<T> FindAll();

        IEnumerable<T> FindByConditions(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
