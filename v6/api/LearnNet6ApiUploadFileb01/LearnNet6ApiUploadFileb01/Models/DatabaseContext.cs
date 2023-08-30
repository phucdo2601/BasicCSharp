using Microsoft.EntityFrameworkCore;

namespace LearnNet6ApiUploadFileb01.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        #region the DbSet for collect data of table on db
        public DbSet<Product> Products { get; set; }
        #endregion

    }
}
