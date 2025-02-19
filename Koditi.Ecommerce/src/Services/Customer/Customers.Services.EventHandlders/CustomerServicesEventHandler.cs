
using MediatR;
using Customer.Persistence.DataBase;
using Customers.Services.EventHandlders.Command;
using Customer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Customer.Services.EventHandlders
{
    public class CustomerServicesEventHandler : INotificationHandler<CustomerCommandEventHandler>
    {
        private readonly ApplicationDbContextCustomer _context;
        private readonly ILogger<CustomerServicesEventHandler> _logger; 
        public CustomerServicesEventHandler(ApplicationDbContextCustomer context, ILogger<CustomerServicesEventHandler> logger)
        {
            _context = context;
            _logger = logger;
            
        }

        public async Task Handle(CustomerCommandEventHandler command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Buscando customer el la Db");
            Domain.Customer? customer =await _context.Customers.FirstOrDefaultAsync(x=>x.CustomerId == command.customerId);

            //Add Customer
            if (customer == null) 
            {
                Domain.Customer NewCustomer = new Domain.Customer()
                {
                    Name = command.Name
                };

                _logger.LogInformation("Al no existir en la Db se creo y almaceno en este momento correctamente");
                await _context.Customers.AddAsync(NewCustomer);
                await _context.SaveChangesAsync();
            }
            else
            {
                //Update Customer

                _logger.LogInformation("Al existir en la DB se actualizo correctamente");
                customer.Name = command.Name;
                await _context.SaveChangesAsync();
            }
        }
    }
}
