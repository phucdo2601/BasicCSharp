using LearnBasicGenericUnitOfWorkb01.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnBasicGenericUnitOfWorkb01.Models.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            //tao khoa chinh
            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.ProductId).UseIdentityColumn();

            //lien ket khoa ngoai(CategoryId) cua bang Item den bang Category
            builder.HasOne(x => x.Category).WithMany(x => x.Items).HasForeignKey(x => x.CategoryId);

            //lien ket khoa ngoai(BrandId) cua bang Item dem bang Brand
            builder.HasOne(x => x.Brand).WithMany(x => x.Items).HasForeignKey(x => x.BrandId);
        }
    }
}
