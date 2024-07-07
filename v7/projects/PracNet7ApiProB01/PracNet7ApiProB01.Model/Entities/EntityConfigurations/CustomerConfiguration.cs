using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            /**
             * One-To-One:
             * Making relationship between Customer and GeneralUserInfo N-To-1
             * One: Customer
             * One: GeneralRole
             */
            builder.HasOne(p => p.GeneralUserInfo)
                .WithOne(p => p.Customer)
                .HasForeignKey<Customer>(p => p.GenUserInfoId);

            /**
             * Set not required fields
             */
            builder.Property(u => u.LastPurchaseDate)
               .IsRequired(false);
        }
    }
}
