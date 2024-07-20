using Microsoft.EntityFrameworkCore;
using PracNet7ApiProB01.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        #region FindAllInclude
        public IQueryable<T> FindAllInclude(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsNoTracking();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
        #endregion

        #region FindByCondition
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate);
        }
        #endregion


        #region FindById
        public T FindById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
        #endregion

        #region Find by Id with id syntax query
        public T FindById02(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }

        #endregion


        #region Update
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        #endregion

    }
}
