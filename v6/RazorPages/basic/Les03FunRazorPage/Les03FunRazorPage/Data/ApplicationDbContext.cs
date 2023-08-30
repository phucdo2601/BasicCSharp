using Les03FunRazorPage.Model;
using Microsoft.EntityFrameworkCore;

namespace Les03FunRazorPage.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }

    }
}
