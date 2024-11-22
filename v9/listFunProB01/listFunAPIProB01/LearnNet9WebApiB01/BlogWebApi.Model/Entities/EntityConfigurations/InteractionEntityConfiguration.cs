using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Model.Entities.EntityConfigurations
{
    public class InteractionEntityConfiguration : IEntityTypeConfiguration<InteractionEntity>
    {
        public void Configure(EntityTypeBuilder<InteractionEntity> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between InteractionEntity and InteractionTypeEntity N-To-1
             * Many: InteractionEntity
             * One: InteractionTypeEntity
             */
            builder.HasOne(p => p.InteractionTypeEntity)
                .WithMany(p => p.InteractionEntities)
                .HasForeignKey(p => p.InteractionTypeId);

            /**
             * One-To-Many:
             * Making relationship between InteractionEntity and User N-To-1
             * Many: InteractionEntity
             * One: User
             */
            builder.HasOne(p => p.UserEntity)
                .WithMany(p => p.InteractionEntities)
                .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);

            /**
             * One-To-Many:
             * Making relationship between InteractionEntity and Blog N-To-1
             * Many: InteractionEntity
             * One: Blog
             */
            builder.HasOne(p => p.BlogEntity)
                .WithMany(p => p.InteractionEntities)
                .HasForeignKey(p => p.BlogId);
        }
    }
}
