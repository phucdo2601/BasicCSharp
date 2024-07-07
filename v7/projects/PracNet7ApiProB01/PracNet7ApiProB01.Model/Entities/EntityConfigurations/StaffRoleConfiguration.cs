using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities.EntityConfigurations
{
    public class StaffRoleConfiguration : IEntityTypeConfiguration<StaffRole>
    {
        public void Configure(EntityTypeBuilder<StaffRole> builder)
        {
            /**
             * One-To-Many:
             * Making relationship between StaffRole and Staff 1-To-N
             * Many: Staff
             * One: StaffRole
             */
            builder.HasMany(p => p.Staffs)
                .WithOne(p => p.StaffRole)
                .HasForeignKey(p => p.StaffRoleId);
        }
    }
}
