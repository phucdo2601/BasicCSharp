using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les40_LearnEntityFrameworkCore.Models
{
    public class DatabaseContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();

        });

        private const string connString = @"Data Source=LAPTOP-7CKON28R\SQLEXPRESS;Initial Catalog=CSharpLes40EntityFrame;User ID=sa;Password=12345678;Encrypt=false";

        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connString);
          /*  optionsBuilder.UseLazyLoadingProxies();*/

        }

        #region set dbset for import or export data on sql - bieu dien bang trong csdl
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        #endregion
    }
}
