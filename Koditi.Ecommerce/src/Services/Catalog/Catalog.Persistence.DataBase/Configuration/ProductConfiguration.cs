using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Catalog.Persistence.DataBase.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> EntityBuilder )
        {
            EntityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            EntityBuilder.Property(x=>x.Description).IsRequired().HasMaxLength(500);
        }
    }
}
