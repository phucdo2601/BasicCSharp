using LearnBasicGenericUnitOfWorkb01.Models;
using LearnBasicGenericUnitOfWorkb01.Models.Entites;
using LearnBasicGenericUnitOfWorkb01.Repositories.Generic;

namespace LearnBasicGenericUnitOfWorkb01.Repositories.Categories
{
    public class CategoryRepository: GenericRepository<Category>, ICategoriesRepository
    {
        public CategoryRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
