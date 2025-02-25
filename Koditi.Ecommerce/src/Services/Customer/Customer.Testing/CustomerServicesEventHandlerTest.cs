
using Customer.Testing.DataBaseTesting;
using Customer.Services.EventHandlders;
using Moq;
using Microsoft.Extensions.Logging;
using Customers.Services.EventHandlders.Command;
using Microsoft.EntityFrameworkCore;
using Customer.Services.EventHandlers;
using Customer.Persistence.DataBase;

namespace Customer.Testing
{
    [TestClass]
    public class CustomerServicesEventHandlerTest
    {

        private  ApplicationDbContextCustomer context;
        private ILogger<CustomerServicesEventHandler> _logger;
        private ILogger<CustomerDeleteEventHandler> _logger2;



        [TestInitialize]
        public void TestInitialize()
        {
            context = ApplicationDbContextCustomerInMemory.Get();
            _logger = new Mock<ILogger<CustomerServicesEventHandler>>().Object;
            _logger2 = new Mock<ILogger<CustomerDeleteEventHandler>>().Object;

        }

        [TestCleanup]
        public void TestCleanup()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void CreateNewCustomer()
        {
           

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
            

            Domain.Customer customer2 = new Domain.Customer()
            {
                Name = "Test2"
            };

            context.Customers.AddAsync(customer2);
            context.SaveChangesAsync();

            CustomerCommandEventHandler UpdateCustomer = new CustomerCommandEventHandler()
            {
                customerId = customer2.CustomerId,
                Name = "TestActualizado",
            };

            var handler = new CustomerServicesEventHandler(context, _logger);

            handler.Handle(UpdateCustomer, new CancellationToken()).Wait();

           
        }

        [TestMethod]
        public void DeleteCustomer()
        {


            Domain.Customer customer3 = new Domain.Customer()
            {
                Name = "TestDelete"
            };

            context.Customers.AddAsync(customer3);
            context.SaveChangesAsync();

            CustomerDeleteCommand customerDelete = new CustomerDeleteCommand()
            {
                customerId = customer3.CustomerId
            };

            var handler = new CustomerDeleteEventHandler(context, _logger2);

            handler.Handle(customerDelete, new CancellationToken()).Wait();


        }

        [TestMethod]
        public  void DeleteCustomerException()
        {



            CustomerDeleteCommand customerDeleteException = new CustomerDeleteCommand()
            {
                customerId = 0
            };

            var handler = new CustomerDeleteEventHandler(context, _logger2);

             Assert.ThrowsExceptionAsync<KeyNotFoundException>(() => handler.Handle(customerDeleteException, new CancellationToken())).Wait();


        }
    }
}
