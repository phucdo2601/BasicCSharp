using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Model.Entities.EntityConfigurations
{
    public class BlogCategoryEntityConfiguration : IEntityTypeConfiguration<BlogCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<BlogCategoryEntity> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between BlogCategory and Blog 1-To-N
             * Many: Blog
             * One: BlogCategory
             */
            builder.HasMany(p => p.BlogEntities)
                .WithOne(p => p.BlogCategory)
                .HasForeignKey(p => p.BlogCategoryId);
        }
    }
}
