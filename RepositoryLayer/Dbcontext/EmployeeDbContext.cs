using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;
using RepositoryLayer.EmployeeEntity; // Import your models

namespace RepositoryLayer.Context
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } // Your table
    }
}
