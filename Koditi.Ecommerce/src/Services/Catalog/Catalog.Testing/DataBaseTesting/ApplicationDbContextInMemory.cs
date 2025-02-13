using Catalog.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Testing.DataBaseTesting
{
    public class ApplicationDbContextInMemory
    {
        public static ApplicationDbContext Get()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Catalog.Db").Options;

            return new ApplicationDbContext(options);
        }
    }
}
