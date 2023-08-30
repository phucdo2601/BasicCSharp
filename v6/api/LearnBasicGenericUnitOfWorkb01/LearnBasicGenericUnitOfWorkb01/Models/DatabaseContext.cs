using LearnBasicGenericUnitOfWorkb01.Models.Configurations;
using LearnBasicGenericUnitOfWorkb01.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace LearnBasicGenericUnitOfWorkb01.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        #region the region for configuration fluentApi

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*base.OnModelCreating(modelBuilder);*/
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
        }

        #endregion

        #region dbset for import and export data on database
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        #endregion

    }
}
