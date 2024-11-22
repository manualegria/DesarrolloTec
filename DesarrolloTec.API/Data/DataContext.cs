using Microsoft.EntityFrameworkCore;
using DesarrolloTec.Shered.Entities;
using DesarrolloTec.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Veterinary.Shared.Entities;

namespace DesarrolloTec.API.Data
{
    public class DataContext:IdentityDbContext<User>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }


        public DbSet<Resource> Resourcess { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<USerTask> USerTasks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<ProjectService> ProjectService { get; set; }
        public DbSet<Service> Services { get; set; }
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
