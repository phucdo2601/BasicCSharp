using LearnBasicGenericUnitOfWorkb01.Models;
using LearnBasicGenericUnitOfWorkb01.Models.Entites;
using LearnBasicGenericUnitOfWorkb01.Repositories.Generic;

namespace LearnBasicGenericUnitOfWorkb01.Repositories.Brands
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
