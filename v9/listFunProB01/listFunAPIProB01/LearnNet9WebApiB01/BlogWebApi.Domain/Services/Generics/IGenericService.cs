using BlogWebApi.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.Generics
{
    public interface IGenericService<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindById(Guid id);
        int Update(T entity);

        int Create(T entity);

        bool Delete(T entity);


    }
}
