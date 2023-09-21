using Microsoft.EntityFrameworkCore;
using PracticeBackendCRUDApib01.Entities;

namespace PracticeBackendCRUDApib01.DatabaseContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        #region set dbset for import or export data on sql - bieu dien bang trong csdl
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        #endregion
    }
}
