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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name= "Action", DisplayOrder = 1},
                new Category { Id = 2, Name= "Science", DisplayOrder = 2},
                new Category { Id = 3, Name= "Biography", DisplayOrder = 3},
                new Category { Id = 4, Name= "AutoBoigraphy", DisplayOrder = 4}
                );
        }
    }
}
