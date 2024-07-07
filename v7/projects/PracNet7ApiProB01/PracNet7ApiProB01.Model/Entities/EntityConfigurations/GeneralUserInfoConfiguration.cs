using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities.EntityConfigurations
{
    public class GeneralUserInfoConfiguration : IEntityTypeConfiguration<GeneralUserInfo>
    {
        public void Configure(EntityTypeBuilder<GeneralUserInfo> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between GeneralRole and GeneralUserInfo N-To-1
             * Many: GeneralUserInfo
             * One: GeneralRole
             */
            builder.HasOne(p => p.GeneralRole)
                .WithMany(p => p.GeneralUserInfos)
                .HasForeignKey(p => p.GenRoleId);

            /**
             * One-To-One:
             * Making relationship between Customer and GeneralUserInfo N-To-1
             * One: Customer
             * One: GeneralRole
             */
            builder.HasOne(p => p.Customer)
                .WithOne(p => p.GeneralUserInfo)
                .HasForeignKey<Customer>(p => p.GenUserInfoId);

            /**
             * One-To-One:
             * Making relationship between Staff and GeneralUserInfo N-To-1
             * One: Staff
             * One: GeneralRole
             */
            builder.HasOne(p => p.Staff)
                .WithOne(p => p.GeneralUserInfo)
                .HasForeignKey<Staff>(p => p.GenUserInfoId);

            /**
             * Set not required fields
             */
            builder.Property(p => p.DateOfCreate).IsRequired(false);
            builder.Property(p => p.DateOfUpdate).IsRequired(false);
        }
    }
}
