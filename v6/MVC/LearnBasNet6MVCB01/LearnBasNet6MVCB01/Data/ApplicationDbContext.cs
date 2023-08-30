using LearnBasNet6MVCB01.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnBasNet6MVCB01.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
                
        }

        public DbSet<Category> Categories { get; set; }
    }
}
