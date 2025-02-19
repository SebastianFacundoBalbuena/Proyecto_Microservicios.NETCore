using Customer.Persistence.DataBase;
using Customers.Services.EventHandlders.Command;
using MediatR;
using Microsoft.Extensions.Logging;
using Customer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Customer.Services.EventHandlers
{
    public  class CustomerDeleteEventHandler : INotificationHandler<CustomerDeleteCommand>
    {
        private readonly ApplicationDbContextCustomer _context;
        private readonly ILogger<CustomerDeleteEventHandler> _logger;   
        public CustomerDeleteEventHandler(ApplicationDbContextCustomer context, ILogger<CustomerDeleteEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(CustomerDeleteCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Buscando el customer a eliminar en la DB");

            Domain.Customer? customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == command.customerId);

            if(customer != null)
            {
                _logger.LogInformation("Se ha eliminado correctamente");
                 _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            else
            {
                _logger.LogInformation("No se ha encontrado al cliente en la DB");
                throw new KeyNotFoundException("No se ha encontrado al cliente en la DB");
            }
        }
    }
}
