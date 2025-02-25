

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Order.Persistence.DataBase.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Domain.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Order> builder)
        {
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x=>x.Total).IsRequired();

        }
    }
}
