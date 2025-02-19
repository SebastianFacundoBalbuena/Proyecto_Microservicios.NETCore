using Catalog.Testing.DataBaseTesting;
using Microsoft.Extensions.Logging;
using Catalog.Service.Queries;
using Moq;
using Catalog.Services.EventHandlers;
using Catalog.Services.EventHandlers.Commands;
using Catalog.Domain;

namespace Catalog.Testing
{
    [TestClass]
    public class ProductCreateEventHandlerTest
    {
        //ObjectFalse, MOQ
        private ILogger<ProductQueryService> GetLogger
        {
            get
            {
                return new Mock<ILogger<ProductQueryService>>().Object;

            }
        }
        private ILogger<ProductDeleteEventHandler> GetLogger2
        {
            get
            {
                return new Mock<ILogger<ProductDeleteEventHandler>>().Object;

            }
        }

        private ILogger<ProductCreateEventHandler> GetLogger3
        {
            get
            {
                return new Mock<ILogger<ProductCreateEventHandler>>().Object;

            }
        }

        [TestMethod]
        public void AddStockProduct()
        {
            var context = ApplicationDbContextInMemory.Get();

            //New Product
            ProductCreateCommand product = new ProductCreateCommand()
            {
                ProductId = 1,
                Name = "Test2",
                Description = "Test2",
                Price = 202
            };



            var handler = new ProductCreateEventHandler(context, GetLogger3);

            handler.Handle(product, new CancellationToken()).Wait();
        }

        [TestMethod]
        public  void RemoveProduct()
        {
            var context = ApplicationDbContextInMemory.Get();

            //Old Product
            Product productOld = new Product()
            {
                ProductId = 2,
                Name = "Test2",
                Description = "Test2",
                Price = 202
            };

            context.Products.Add(productOld);
            context.SaveChanges();

            //New Product
            ProductDeleteCommand product = new ProductDeleteCommand()
            {
                ProductId = 0
            };


            var handler = new ProductDeleteEventHandler(context, GetLogger2);

             Assert.ThrowsExceptionAsync<KeyNotFoundException>(() => handler.Handle(product, new CancellationToken())).Wait();

        }
    }
}