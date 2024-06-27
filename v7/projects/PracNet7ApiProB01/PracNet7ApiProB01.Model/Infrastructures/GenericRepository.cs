using Microsoft.EntityFrameworkCore;
using PracNet7ApiProB01.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Infrastructures
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PracNet7ApiDbContext _context;

        protected GenericRepository(PracNet7ApiDbContext _context)
        {
            this._context = _context;
        }

        #region CreateNew
        public void CreateNew(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        #endregion

        #region Delete
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        #endregion

        #region FindAll
        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }
        #endregion


        #region FindById
        public T FindById(string id)
        {
            return _context.Set<T>().Find(id);
        }
        #endregion


        #region Update
        public void Update(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        #endregion

    }
}
