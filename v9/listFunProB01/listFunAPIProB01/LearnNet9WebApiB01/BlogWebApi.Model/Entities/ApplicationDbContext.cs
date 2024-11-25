using BlogWebApi.Model.Entities.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BlogWebApi.Model.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        #region the region import and export data
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<BlogCategoryEntity> BlogCategoryEntities { get; set; }
        public DbSet<BlogEntity> BlogEntities { get; set; }
        public DbSet<CommentEntity> CommentEntities { get; set; }
        public DbSet<LikeEntity> LikeEntities { get; set; }
        public DbSet<ShareEntity> ShareEntities { get; set; }
        public DbSet<InteractionEntity> InteractionEntities { get; set; }
        #endregion

        #region the region for add configuration db setting
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(UtilsConstant.CONNECTION_STR);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BlogCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BlogEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CommentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LikeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ShareEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InteractionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InteractionTypeEntityConfiguration());
        }

        #endregion
    }
}
