using LearnBasicGenericUnitOfWorkb01.Models;
using LearnBasicGenericUnitOfWorkb01.Models.Entites;
using LearnBasicGenericUnitOfWorkb01.Repositories.Generic;

namespace LearnBasicGenericUnitOfWorkb01.Repositories.Items
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
