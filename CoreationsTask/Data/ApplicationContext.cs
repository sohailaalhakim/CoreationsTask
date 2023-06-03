using CoreationsTask.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading.Channels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CoreationsTask
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public ApplicationContext() { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }












    }
}
