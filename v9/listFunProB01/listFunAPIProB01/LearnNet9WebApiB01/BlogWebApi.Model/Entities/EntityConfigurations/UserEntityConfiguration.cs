using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Model.Entities.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between User and Role N-To-1
             * Many: User
             * One: Role
             */
            builder.HasOne(p => p.RoleEntity)
                .WithMany(p => p.UserEntities)
                .HasForeignKey(p => p.RoleId);

            /**
             * One-To-Many:
             * Making relationship between User and Interaction 1-N
             * Many: Interaction
             * One: User
             */
            builder.HasMany(p => p.InteractionEntities)
                .WithOne(p => p.UserEntity)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            /**
             * One-To-Many:
             * Making relationship between User and CommentEntities 1-N
             * Many: CommentEntities
             * One: User
             */
            builder.HasMany(p => p.CommentEntities)
                .WithOne(p => p.UserEntity)
                .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);

            /**
             * One-To-Many:
             * Making relationship between User and LikeEntities 1-N
             * Many: LikeEntities
             * One: User
             */
            builder.HasMany(p => p.LikeEntities)
                .WithOne(p => p.UserEntity)
                .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);

            /**
             * One-To-Many:
             * Making relationship between User and ShareEntities 1-N
             * Many: ShareEntities
             * One: User
             */
            builder.HasMany(p => p.ShareEntities)
                .WithOne(p => p.UserEntity)
                .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);

            /**
             * One-To-Many:
             * Making relationship between User and Blogs 1-N
             * Many: Blogs
             * One: User
             */
            builder.HasMany(p => p.BlogEntities)
                .WithOne(p => p.UserEntity)
                .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
