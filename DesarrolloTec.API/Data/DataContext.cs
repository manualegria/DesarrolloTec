using Microsoft.EntityFrameworkCore;
using DesarrolloTec.Shered.Entities;
using DesarrolloTec.Shared.Entities;

namespace DesarrolloTec.API.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<ProjectService> ProjectServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Resource> Resourcess { get; set; }
        public DbSet<Invoice> Invoices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
