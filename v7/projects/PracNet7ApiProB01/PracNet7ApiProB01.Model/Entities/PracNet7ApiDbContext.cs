using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities
{
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(connectionStr);
        }
    }
}
