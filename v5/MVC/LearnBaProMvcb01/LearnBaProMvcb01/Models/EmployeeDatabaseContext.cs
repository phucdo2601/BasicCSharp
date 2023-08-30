using Microsoft.EntityFrameworkCore;

namespace LearnBaProMvcb01.Models
{
    public class EmployeeDatabaseContext : DbContext
    {
        public EmployeeDatabaseContext(DbContextOptions<EmployeeDatabaseContext> options) : base(options) 
        {

        }

        #region list DbSet
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        #endregion
    }
}
