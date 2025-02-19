
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Persistence.DataBase.Configuration
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<Domain.Customer> EntityBuilder)
        {

            EntityBuilder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            
        }
    }
}
