using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities.EntityConfigurations
{
    public class GeneralRoleConfiguration : IEntityTypeConfiguration<GeneralRole>
    {
        public void Configure(EntityTypeBuilder<GeneralRole> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between GeneralRole and GeneralUserInfo 1-To-N
             * Many: GeneralUserInfo
             * One: GeneralRole
             */
            builder.HasMany(p => p.GeneralUserInfos)
                .WithOne(p => p.GeneralRole)
                .HasForeignKey(p => p.GenRoleId);
        }
    }
}
