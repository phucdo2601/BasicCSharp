using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        T FindById(Guid id);
        #endregion

        #region Find by Id with id syntax query
        T FindById02(Expression<Func<T, bool>> predicate);

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

        #region FindByCondition
        /**
       * Linq Expression: https://viblo.asia/p/linq-expression-m68Z0yNjlkG
       *  Expression đại diện cho biểu thức lambda mạnh mẽ. Nó có nghĩa là biểu thức lambda cũng có thể được gán cho loại Expression<TDelegate>. 
       *  Trình biên dich .NET chuyển đổi biểu thức lambda được gán cho biểu thức Expression<TDelegate> thành một cây biểu thức Expression
       *  thay vì mã thực thi. 
       */
        /**
         * IQueryable
         * System.Linq
         * Duyệt phần tử theo chiều tiến lên.
         * Truy vấn tốt nhất đối với những dữ liệu nằm ngoài bộ nhớ như cơ sở dữ liệu.
         * Truy vấn và lọc dữ liệu trên server và dữ liệu trả về cho client.
         */
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate);

        /**
         * Lấy list data cuar mootj object bao gom casc object con (object lien ket) - khi su dung
         * EF CORE va Linq
         */
        IQueryable<T> FindAllInclude(params Expression<Func<T, object>>[] includes);

        #endregion
    }
}
