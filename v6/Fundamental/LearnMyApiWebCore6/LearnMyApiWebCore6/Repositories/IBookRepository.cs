using LearnMyApiWebCore6.Data;
using LearnMyApiWebCore6.Models;

namespace LearnMyApiWebCore6.Repositories
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBooksAsync();

        public Task<BookModel> GetBookByIdAsync(int id);

        public Task<int> AddBookAsync(BookModel model);

        //khong can tra ve du lieu, thi khong can dat kieu du lieu trong Task
        public Task UpdateBookAsync(int id, BookModel model);
        public Task DeleteBookAsync(int id);
    }
}
