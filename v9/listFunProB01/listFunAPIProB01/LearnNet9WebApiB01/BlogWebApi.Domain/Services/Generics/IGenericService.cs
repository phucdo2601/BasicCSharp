using BlogWebApi.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.Generics
{
    public interface IGenericService<T> where T : class
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByConditions(Expression<Func<T, bool>> predicate);

        T FindById(Guid id);
        T Update(T entity);

        T Create(T entity);

        bool Delete(T entity);


    }
}
