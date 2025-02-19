using Customer.Domain;
using Customer.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Customer.Services.Query
{
    public class CustomerServicesQuery
    {
        private readonly ApplicationDbContextCustomer _context;
        public CustomerServicesQuery(ApplicationDbContextCustomer context)
        {
            _context = context;
        }

        public async Task<List<Domain.Customer>> GetAll()
        {
            List<Domain.Customer>? list = await _context.Customers.ToListAsync();

            return list;
        }

        public async Task<Domain.Customer> GetId(int id)
        {
            Domain.Customer? customer = await  _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);

            return customer;
        }
    }
}
