using EfCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Data
{
    // DbContext is where the magic happen
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Group> Groups { get; set; }
        //public DbSet<CustomerGroup> CustomerGroups {get;set;}
        // public DbSet<VipCustomer> VipCustomers { get; set; }
        // public DbSet<SchoolCustomer> SchoolCustomers { get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // model builder to enable fluent mapping to
            // our obj to handle cuncurrency
            modelBuilder.Entity<Customer>()
                .Property(x => x.RowVersion)
                    .IsRowVersion();

            // TPT table per type 
            modelBuilder.Entity<VipCustomer>().ToTable("VipCustomers");
            modelBuilder.Entity<SchoolCustomer>().ToTable("SchoolCustomers");

            base.OnModelCreating(modelBuilder);
        }
    }
}