using Microsoft.EntityFrameworkCore;
using Order.Persistence.DataBase.Configurations;

namespace Order.Persistence.DataBase
{
    public class ApplicationDbContextOrder : DbContext
    {
        public ApplicationDbContextOrder(DbContextOptions<ApplicationDbContextOrder> options) : base(options)
        {

        }

        public DbSet<Domain.Order> Orders { get; set; }
        public DbSet<Domain.OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Order");

            modelBuilder.ApplyConfiguration(new OrderConfigurations());
        }

        
    }
}
