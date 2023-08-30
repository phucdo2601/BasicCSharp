using LearnBasicGenericUnitOfWorkb01.Repositories.Brands;
using LearnBasicGenericUnitOfWorkb01.Repositories.Categories;
using LearnBasicGenericUnitOfWorkb01.Repositories.Items;

namespace LearnBasicGenericUnitOfWorkb01.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();

        Task<bool> SaveAsync();

        Task<int> SaveAsync2();

        ICategoriesRepository CategoryRepository { get; }
        IBrandRepository BrandRepository { get; }
        IItemRepository ItemRepository { get; }

    }
}
