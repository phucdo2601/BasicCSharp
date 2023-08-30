using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearnMyApiWebCore6.Data
{
    /**
     * Neu su dung identity de ho tro authen thi, thay the DbContext bang IdentityDbContext voi lop user da dinh nghia
     */
    public class BookStoreContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> opt) : base(opt)
        {

        }

        #region DbSet
        public DbSet<Book>? Books { get; set; }
        #endregion

    }
}
