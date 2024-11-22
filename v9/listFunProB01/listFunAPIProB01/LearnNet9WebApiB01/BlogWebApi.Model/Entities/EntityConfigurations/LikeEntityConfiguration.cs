using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Model.Entities.EntityConfigurations
{
    public class LikeEntityConfiguration : IEntityTypeConfiguration<LikeEntity>
    {
        public void Configure(EntityTypeBuilder<LikeEntity> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between Like and Blog N-To-1
             * Many: Like
             * One: Blog
             */
            builder.HasOne(p => p.BlogEntity)
                .WithMany(p => p.LikeEntities)
                .HasForeignKey(p => p.BlogId);

            /**
             * One-To-Many:
             * Making relationship between Like and User N-To-1
             * Many: Like
             * One: User
             */
            builder.HasOne(P => P.UserEntity)
                .WithMany(p => p.LikeEntities)
                .HasForeignKey(p => p.UserId);
        }
    }
}
