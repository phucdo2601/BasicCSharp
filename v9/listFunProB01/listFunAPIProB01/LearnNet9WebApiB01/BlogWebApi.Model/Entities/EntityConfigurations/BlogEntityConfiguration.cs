using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Model.Entities.EntityConfigurations
{
    public class BlogEntityConfiguration : IEntityTypeConfiguration<BlogEntity>
    {
        public void Configure(EntityTypeBuilder<BlogEntity> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between Blog and BlogCategory N-To-1
             * Many: Blog
             * One: BlogCategory
             */
            builder.HasOne(p => p.BlogCategory)
                .WithMany(p => p.BlogEntities)
                .HasForeignKey(p => p.BlogCategoryId);

            /**
             * One-To-Many:
             * Making relationship between Blog and User N-To-1
             * Many: Blog
             * One: BlogCategory
             */
            builder.HasOne(p => p.UserEntity)
                .WithMany(p => p.BlogEntities)
                .HasForeignKey(p => p.UserId);

            /**
             * One-To-Many:
             * Making relationship between Blog and Comment 1-To-N
             * Many: Comment
             * One: Blog
             */
            builder.HasMany(p => p.CommentEntities)
                .WithOne(p => p.BlogEntity)
                .HasForeignKey(p => p.BlogId);

            /**
             * One-To-Many:
             * Making relationship between Blog and InteractionEntity 1-To-N
             * Many: InteractionEntity
             * One: Blog
             */
            builder.HasMany(p => p.InteractionEntities)
                .WithOne(p => p.BlogEntity)
                .HasForeignKey(p => p.BlogId);

            /**
             * One-To-Many:
             * Making relationship between Blog and Like 1-To-N
             * Many: Like
             * One: Blog
             */
            builder.HasMany(p => p.LikeEntities)
                .WithOne(p => p.BlogEntity)
                .HasForeignKey(p => p.BlogId);
        }
    }
}
