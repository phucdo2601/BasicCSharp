using LearnNet9MVCFunLes01Web.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnNet9MVCFunLes01Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        #region the region import and export data
        public DbSet<Category> Categories { get; set; }
        #endregion
    }
}
