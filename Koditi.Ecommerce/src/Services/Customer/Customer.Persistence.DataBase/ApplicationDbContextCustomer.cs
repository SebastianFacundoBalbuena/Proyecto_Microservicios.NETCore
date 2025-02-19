using Microsoft.EntityFrameworkCore;
using Customer.Domain;
using Customer.Persistence.DataBase.Configuration;
namespace Customer.Persistence.DataBase
{
    public class ApplicationDbContextCustomer : DbContext
    {
        public ApplicationDbContextCustomer(DbContextOptions<ApplicationDbContextCustomer> options) : base(options)
        {

        }

        public DbSet<Domain.Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            base.OnModelCreating(ModelBuilder);

            ModelBuilder.HasDefaultSchema("Customer");

            ModelConfig(ModelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new CustomerConfiguration(modelBuilder.Entity<Domain.Customer>());
        }
    }
}
