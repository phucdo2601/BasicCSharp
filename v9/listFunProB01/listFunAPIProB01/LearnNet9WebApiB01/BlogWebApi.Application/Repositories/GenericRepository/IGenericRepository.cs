using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Application.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        T FindById(Guid id);

        IEnumerable<T> FindAll();

        void Add(T entity);

        void Update(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
