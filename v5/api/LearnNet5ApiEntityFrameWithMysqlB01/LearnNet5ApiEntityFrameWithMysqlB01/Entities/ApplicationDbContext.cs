using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace LearnNet5ApiEntityFrameWithMysqlB01.Entities
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        #region List DbSet for migration objects
        public DbSet<Person> Persons { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(e => e.Property(o => o.Age).HasConversion<short>());
            modelBuilder.Entity<Person>(e => e.Property(o => o.IsPlayer).HasConversion(new BoolToZeroOneConverter<Int16>()).HasColumnType("bit"));
        }
    }
}
