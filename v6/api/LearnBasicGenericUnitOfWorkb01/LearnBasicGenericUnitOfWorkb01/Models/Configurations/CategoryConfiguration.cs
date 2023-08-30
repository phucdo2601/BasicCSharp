using LearnBasicGenericUnitOfWorkb01.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnBasicGenericUnitOfWorkb01.Models.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            //set khoa chinh cho bang
            builder.HasKey(x => x.CategoryId);

            //set truong tu tang trong bang
            builder.Property(x => x.CategoryId).UseIdentityColumn();

            //set cac truong du lieu khac
            builder.Property(x => x.CategoryName).HasMaxLength(255).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(255);

            builder.Property(x => x.DateOfCreate).HasDefaultValue(DateTime.UtcNow);
            

        }
    }
}
