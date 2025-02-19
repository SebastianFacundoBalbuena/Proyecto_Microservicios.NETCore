using Catalog.Services.EventHandlers;
using Catalog.Services.EventHandlers.Commands;
using Catalog.Testing.DataBaseTesting;
using Moq;
using Microsoft.Extensions.Logging;

namespace Catalog.Testing
{
    [TestClass]
    public class ProductInStockHandlerTesting
    {
        //Moq del logger 
        private ILogger<ProductInStockEventHandler> GetLogger
        {
            get
            {
                return new Mock<ILogger<ProductInStockEventHandler>>().Object;
            }
        }

        [TestMethod]
        public void ProductInStockCreateHandler()
        {
            var context = ApplicationDbContextInMemory.Get();


            ProductInStockCommands productNew = new ProductInStockCommands()
            {
                ProductId = 1,
                Stock = 10
            };

            var handler = new ProductInStockEventHandler(context, GetLogger);
            handler.Handle(productNew, new CancellationToken()).Wait();
        }
    }
}
