using Catalog.Domain;
using Catalog.Persistence.DataBase;
using Catalog.Services.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Services.EventHandlers
{
    public class ProductInStockEventHandler : INotificationHandler<ProductInStockCommands>
    {
        private readonly ApplicationDbContext _Context;

        public ProductInStockEventHandler(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task Handle(ProductInStockCommands command, CancellationToken cancellationToken)
        {
            ProductInStock? ExistStock = await _Context.Stocks.FirstOrDefaultAsync(x => x.ProductInStockId == command.ProductInStockId);

            if(ExistStock == null)
            {

                //Create Stock

                var newStock = new ProductInStock()
                {
                    ProductId = command.ProductId,
                    Stock = command.Stock,
                };

                await _Context.Stocks.AddAsync(newStock);
                await _Context.SaveChangesAsync();


            }
            else
            {
                //Update Stock

                ExistStock.Stock = command.Stock;
                await _Context.SaveChangesAsync();
            }


        }

    }
}
