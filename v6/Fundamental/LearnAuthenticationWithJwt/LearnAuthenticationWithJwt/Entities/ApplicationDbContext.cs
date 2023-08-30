using Microsoft.EntityFrameworkCore;

namespace LearnAuthenticationWithJwt.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public virtual DbSet<User> Users { get; set; }  
    }
}
