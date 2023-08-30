using LearnNet6MVCShoppingCartB01.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnNet6MVCShoppingCartB01.Infrastructure
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
