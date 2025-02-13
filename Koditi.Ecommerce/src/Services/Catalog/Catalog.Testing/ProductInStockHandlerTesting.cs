using Catalog.Services.EventHandlers;
using Catalog.Services.EventHandlers.Commands;
using Catalog.Testing.DataBaseTesting;
using Catalog.Domain;

namespace Catalog.Testing
{
    [TestClass]
    public class ProductInStockHandlerTesting
    {
        [TestMethod]
        public void ProductInStockCreateHandler()
        {
            var context = ApplicationDbContextInMemory.Get();


            ProductInStockCommands productNew = new ProductInStockCommands()
            {
                ProductId = 1,
                Stock = 10
            };

            var handler = new ProductInStockEventHandler(context);
            handler.Handle(productNew, new CancellationToken()).Wait();
        }
    }
}
