using Microsoft.EntityFrameworkCore;
using DesarrolloTec.Shered.Entities;

namespace DesarrolloTec.API.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        public DbSet<Customer>Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
