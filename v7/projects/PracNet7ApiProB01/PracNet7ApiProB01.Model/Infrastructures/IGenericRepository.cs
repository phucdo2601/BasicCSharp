using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Infrastructures
{
    public interface IGenericRepository<T>
    {
        #region Find All
        IQueryable<T> FindAll();
        #endregion

        #region Find by id
        T FindById(string id);
        #endregion

        #region Create new
        void CreateNew(T entity);
        #endregion

        #region Update 
        void Update(T entity);
        #endregion

        #region Delete
        void Delete(T entity);
        #endregion


    }
}
