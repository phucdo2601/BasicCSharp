using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Model.Entities.EntityConfigurations
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between Role and User 1-To-N
             * Many: User
             * One: Role
             */
            builder.HasMany(p => p.UserEntities)
                .WithOne(p => p.RoleEntity)
                .HasForeignKey(p => p.RoleId);

            /**
             * Seeding data on database
             */
            builder.HasData(
                new RoleEntity
                {
                    Id = Guid.NewGuid(),
                    RoleTitle = "ADMIN",
                    DateOfCreated = DateTime.Now,
                    DateOfModified = DateTime.Now,
                },
                new RoleEntity
                {
                    Id = Guid.NewGuid(),
                    RoleTitle = "USER",
                    DateOfCreated = DateTime.Now,
                    DateOfModified = DateTime.Now,
                }
                );
        }
    }
}
