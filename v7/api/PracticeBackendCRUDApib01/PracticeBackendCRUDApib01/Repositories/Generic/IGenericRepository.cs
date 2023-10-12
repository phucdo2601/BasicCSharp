using System.Linq.Expressions;

namespace PracticeBackendCRUDApib01.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        /**
         * https://codelearn.io/sharing/ienumerable-khac-iqueryable
         * Khi sử dụng IEnumerable, câu lệnh truy vấn sẽ thực hiện trên máy chủ và trả về dữ liệu cho client. 
         * Sau khi trả hết dữ liệu, client mới thực hiện lấy 2 bản ghi đầu tiên.

           Khi sử dụng IQueryable, câu lệnh truy vấn sẽ thực hiện trên máy chủ, 
            lọc trên máy chủ và trả dữ liệu cho client.
         */
        IEnumerable<T> GetAll();

        T GetById(int id);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindAll();

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

    }
}
