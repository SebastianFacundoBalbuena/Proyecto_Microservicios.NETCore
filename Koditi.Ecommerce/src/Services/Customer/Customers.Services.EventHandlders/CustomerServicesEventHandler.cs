
using MediatR;
using Customer.Persistence.DataBase;
using Customers.Services.EventHandlders.Command;
using Customer.Domain;
using Microsoft.EntityFrameworkCore;


namespace Customer.Services.EventHandlders
{
    public class CustomerServicesEventHandler : INotificationHandler<CustomerCommandEventHandler>
    {
        private readonly ApplicationDbContextCustomer _context;
        public CustomerServicesEventHandler(ApplicationDbContextCustomer context)
        {
            _context = context;
            
        }

        public async Task Handle(CustomerCommandEventHandler command, CancellationToken cancellationToken)
        {
            Domain.Customer? customer =await _context.Customers.FirstOrDefaultAsync(x=>x.CustomerId == command.ClientId);

            //Add Customer
            if (customer == null) 
            {
                Domain.Customer NewCustomer = new Domain.Customer()
                {
                    Name = command.Name
                };

                await _context.Customers.AddAsync(NewCustomer);
                await _context.SaveChangesAsync();
            }
            else
            {
                //Update Customer

                customer.Name = command.Name;
                await _context.SaveChangesAsync();
            }
        }
    }
}
