using LearnBasicGenericUnitOfWorkb01.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnBasicGenericUnitOfWorkb01.Models.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            //set up ten bang
            builder.ToTable("Brand");
            //set up primary key
            builder.HasKey(x => x.BrandId);
            builder.Property(x => x.BrandId).UseIdentityColumn();

            //set up cac truong du lieu khac
            builder.Property(x => x.BrandName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.RegisterDate).HasDefaultValue(DateTime.UtcNow);

        }
    }
}
