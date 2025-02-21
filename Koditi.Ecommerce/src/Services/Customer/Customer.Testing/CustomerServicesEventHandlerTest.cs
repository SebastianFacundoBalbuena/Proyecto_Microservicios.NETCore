
using Customer.Testing.DataBaseTesting;
using Customer.Services.EventHandlders;
using Moq;
using Microsoft.Extensions.Logging;
using Customers.Services.EventHandlders.Command;

namespace Customer.Testing
{
    [TestClass]
    public class CustomerServicesEventHandlerTest
    {
        private ILogger<CustomerServicesEventHandler> _logger
        {
            get
            {
                return new Mock<ILogger<CustomerServicesEventHandler>>().Object;
            }
        }

        [TestMethod]
        public void CreateNewCustomer()
        {
            var context = ApplicationDbContextCustomerInMemory.Get();

            CustomerCommandEventHandler customer = new CustomerCommandEventHandler()
            {
                Name = "Test",
            };

            var handler = new CustomerServicesEventHandler(context, _logger);

            handler.Handle(customer, new CancellationToken()).Wait();
        }

        [TestMethod]
        public void UpdateCustomer()
        {
            var context = ApplicationDbContextCustomerInMemory.Get();

            Domain.Customer customer = new Domain.Customer()
            {
                Name = "Test2"
            };

            context.Customers.AddAsync(customer);
            context.SaveChangesAsync();

            CustomerCommandEventHandler UpdateCustomer = new CustomerCommandEventHandler()
            {
                customerId = customer.CustomerId,
                Name = "TestActualizado",
            };

            var handler = new CustomerServicesEventHandler(context, _logger);

            handler.Handle(UpdateCustomer, new CancellationToken()).Wait();

        }
    }
}
