using Microsoft.EntityFrameworkCore;
using PracticeBackendCRUDApib01.Entities;

namespace PracticeBackendCRUDApib01.DatabaseContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        #region set dbset for import or export data on sql - bieu dien bang trong csdl
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ReviewType> ReviewTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }


        #endregion
    }
}
