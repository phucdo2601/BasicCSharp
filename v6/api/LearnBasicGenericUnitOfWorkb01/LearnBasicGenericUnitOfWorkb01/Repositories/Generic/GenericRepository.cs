using LearnBasicGenericUnitOfWorkb01.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LearnBasicGenericUnitOfWorkb01.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        /**
         * AsNoTracking:
         * Trả về một truy vấn mới mà ở đó các thực thể sẽ không được cached trong DBContext (Thừa kế từ DBQuery)
         * Những thực thể trả vềnhư AsNoTracking sẽ không được theo dõi bởi DBContext. 
         * Điều này sẽ làm tăng hiệu năng đáng kể cho những thực thể read only.
         */
        public IEnumerable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate);
        }

        public IQueryable<T> FindInclude(params Expression<Func<T, bool>>[] includes)
        {
            var query = _context.Set<T>().AsNoTracking();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public IQueryable<T> FindIncludeByCondition(Expression<Func<T, bool>> predicate, params Expression<Func<T, bool>>[] includes)
        {
            var query = _context.Set<T>().AsNoTracking().Where(predicate);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveAll(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
