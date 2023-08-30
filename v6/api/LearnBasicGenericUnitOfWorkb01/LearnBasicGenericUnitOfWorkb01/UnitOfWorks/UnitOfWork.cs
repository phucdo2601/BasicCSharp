using LearnBasicGenericUnitOfWorkb01.Models;
using LearnBasicGenericUnitOfWorkb01.Repositories.Brands;
using LearnBasicGenericUnitOfWorkb01.Repositories.Categories;
using LearnBasicGenericUnitOfWorkb01.Repositories.Items;

namespace LearnBasicGenericUnitOfWorkb01.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        /**
         * tiem repository trong day
         */
        public ICategoriesRepository CategoryRepository => new CategoryRepository(_context);

        public IBrandRepository BrandRepository => new BrandRepository(_context);

        public IItemRepository ItemRepository => new ItemRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        /**
                 * Lớp ChangeTracker chịu trách nhiệm theo dõi các thực thể được tải 
                 * vào Ngữ cảnh. Nó làm như vậy bằng cách tạo một thể hiện của lớp 
                 * EntityEntry cho mọi thực thể. ChnageTracker duy trì Trạng thái Thực thể, 
                 * Giá trị Ban đầu, Giá trị Hiện tại, v.v. của từng thực thể trong 
                 * lớp EntityEntry.
                 */
        public int Save()
        {
            int result = _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return result;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                int result = await _context.SaveChangesAsync();
                _context.ChangeTracker.Clear();
                return result > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> SaveAsync2()
        {
            try
            {
                int res = await _context.SaveChangesAsync();
                _context.ChangeTracker.Clear();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
