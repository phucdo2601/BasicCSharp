using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Model.Entities.EntityConfigurations
{
    public class ShareEntityConfiguration : IEntityTypeConfiguration<ShareEntity>
    {
        public void Configure(EntityTypeBuilder<ShareEntity> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between ShareEntities and Blog N-To-1
             * Many: Like
             * One: Blog
             */
            builder.HasOne(p => p.BlogEntity)
                .WithMany(p => p.ShareEntities)
                .HasForeignKey(p => p.BlogId);

            /**
             * One-To-Many:
             * Making relationship between ShareEntities and User N-To-1
             * Many: Like
             * One: User
             */
            builder.HasOne(P => P.UserEntity)
                .WithMany(p => p.ShareEntities)
                .HasForeignKey(p => p.UserId);
        }
    }
}
