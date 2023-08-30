using Microsoft.EntityFrameworkCore;

namespace LearnNet5EntityFrameB01.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
                
        }

        #region Set dbset for for using table in db
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        #endregion
    }
}
