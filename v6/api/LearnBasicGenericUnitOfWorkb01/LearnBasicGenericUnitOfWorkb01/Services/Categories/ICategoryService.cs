using LearnBasicGenericUnitOfWorkb01.Dtos.Request;
using LearnBasicGenericUnitOfWorkb01.Models.Entites;

namespace LearnBasicGenericUnitOfWorkb01.Services.Categories
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();

        Category GetCategoryById(int id);

        int CreateCategory(CategoryRequestModel categoryRequest);

        int UpdateCategory(int id, CategoryRequestModel categoryRequest);
    }
}
