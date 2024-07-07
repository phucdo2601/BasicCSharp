using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities.EntityConfigurations
{
    public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between ProductBrand and Product 1-To-N
             * Many: Product
             * One: ProductBrand
             */
            builder.HasMany(p => p.Products)
                .WithOne(b => b.ProductBrand)
                .HasForeignKey(b => b.ProductBrandId);

            /**
             * Set not required fields
             */
            builder.Property(p => p.DateOfCreate).IsRequired(false);
            builder.Property(p => p.DateOfUpdate).IsRequired(false);
        }
    }
}
