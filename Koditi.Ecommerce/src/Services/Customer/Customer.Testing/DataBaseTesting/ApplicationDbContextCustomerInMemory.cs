using Customer.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Customer.Testing.DataBaseTesting
{
    public class ApplicationDbContextCustomerInMemory
    {
        public static ApplicationDbContextCustomer Get()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContextCustomer>()
                .UseInMemoryDatabase(databaseName: "Customer.DataBase").Options;

            return new ApplicationDbContextCustomer(options);
        }
    }
}
