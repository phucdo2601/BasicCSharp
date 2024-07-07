using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between Product and ProductBrand N-To-1
             * Many: Product
             * One: ProductBrand
             */
            builder.HasOne(p => p.ProductBrand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.ProductBrandId);

            /**
             * Set not required fields
             */
            builder.Property(p => p.DateOfCreate).IsRequired(false);
            builder.Property(p => p.DateOfUpdate).IsRequired(false);
        }
    }
}
