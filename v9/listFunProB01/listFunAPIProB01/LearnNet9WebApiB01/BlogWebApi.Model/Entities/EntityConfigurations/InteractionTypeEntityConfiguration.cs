using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Model.Entities.EntityConfigurations
{
    public class InteractionTypeEntityConfiguration : IEntityTypeConfiguration<InteractionTypeEntity>
    {
        public void Configure(EntityTypeBuilder<InteractionTypeEntity> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between InteractionTypeEntity and InteractionEntity 1-To-N
             * Many: InteractionEntity
             * One: InteractionTypeEntity
             */
            builder.HasMany(p => p.InteractionEntities)
                .WithOne(p => p.InteractionTypeEntity)
                .HasForeignKey(p => p.InteractionTypeId);
        }
    }
}
