using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Model.Entities.EntityConfigurations
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between Comment and Blog N-To-1
             * Many: Comment
             * One: Blog
             */
            builder.HasOne(p => p.BlogEntity)
                .WithMany(p => p.CommentEntities)
                .HasForeignKey(p => p.BlogId);

            /**
             * One-To-Many:
             * Making relationship between Comment and User N-To-1
             * Many: Comment
             * One: User
             */
            builder.HasOne(P => P.UserEntity)
                .WithMany(p => p.CommentEntities)
                .HasForeignKey(p => p.UserId);
        }
    }
}
