using Microsoft.EntityFrameworkCore;
using PracNet7ApiProB01.Model.Entities.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities
{
    /// <summary>
    /// Class for configuration for adapting datetime of using postgre sql
    /// note: Npgsql.EnableLegacyTimestampBehavior
    /// </summary>
    public static class MyMoudleInitializer
    {
        [ModuleInitializer]
        public static void Initialize()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }

    public class PracNet7ApiDbContext : DbContext
    {
        public PracNet7ApiDbContext()
        {
            
        }
        protected PracNet7ApiDbContext(DbContextOptions<PracNet7ApiDbContext> options) : base(options)
        {
        }

        private string connectionStr = @"Host=localhost;Port=5337;Database=p-net7-web-api-pro-2024-b01-dev-db;Username=postgres;Password=12345678";

        public DbSet<GeneralRole> GeneralRoles { get; set; }
        public DbSet<GeneralUserInfo> GeneralUserInfo { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffRole> StaffRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(connectionStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///**
            // * Making rel 1-TO-M between GeneralRoles AND GeneralUserInfo
            // */
            //modelBuilder.Entity<GeneralUserInfo>()
            //    .HasOne<GeneralRole>(s => s.GeneralRole)
            //    .WithMany(g => g.GeneralUserInfos)
            //    .HasForeignKey(s => s.GenRoleId);

            ///**
            // * Making rel 1-TO-M between StaffRole AND Staff
            // */
            //modelBuilder.Entity<Staff>()
            //    .HasOne<StaffRole>(s => s.StaffRole)
            //    .WithMany(g => g.Staffs)
            //    .HasForeignKey(s => s.StaffRoleId);

            ///**
            // * Making 1-TO-1 between GeneralUserInfo and Staff
            // * GeneralUserInfoId is ForeignKey => Staff entity includes one GeneralUserInfo
            // */
            //modelBuilder.Entity<Staff>()
            //    .HasOne<GeneralUserInfo>(s => s.GeneralUserInfo)
            //    .WithOne(g => g.Staff)
            //    .HasForeignKey<Staff>(ad => ad.GenUserInfoId);

            ///**
            // * Making 1-TO-1 between GeneralUserInfo and Customer
            // * GeneralUserInfoId is ForeignKey => Customer entity includes one GeneralUserInfo
            // */
            //modelBuilder.Entity<Customer>()
            //    .HasOne<GeneralUserInfo>(s => s.GeneralUserInfo)
            //    .WithOne(g => g.Customer)
            //    .HasForeignKey<Customer>(ad => ad.GenUserInfoId);

            // Add Entities Configuration
            modelBuilder.ApplyConfiguration(new GeneralRoleConfiguration());
            modelBuilder.ApplyConfiguration(new GeneralUserInfoConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new StaffRoleConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new ProductBrandConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
