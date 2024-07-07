using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities.EntityConfigurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between StaffRole and Staff 1-To-N
             * Many: Staff
             * One: StaffRole
             */
            builder.HasOne(p => p.StaffRole)
                .WithMany(p => p.Staffs)
                .HasForeignKey(p => p.StaffRoleId);

            /**
             * One-To-One:
             * Making relationship between Staff and GeneralUserInfo N-To-1
             * One: Staff
             * One: GeneralRole
             */
            builder.HasOne(p => p.GeneralUserInfo)
                .WithOne(p => p.Staff)
                .HasForeignKey<Staff>(p => p.GenUserInfoId);
        }
    }
}
