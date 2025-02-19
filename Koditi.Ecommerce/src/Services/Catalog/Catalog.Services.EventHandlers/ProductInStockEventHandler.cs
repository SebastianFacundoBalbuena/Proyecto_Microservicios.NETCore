using Catalog.Domain;
using Catalog.Persistence.DataBase;
using Catalog.Services.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Catalog.Services.EventHandlers
{
    public class ProductInStockEventHandler : INotificationHandler<ProductInStockCommands>
    {
        private readonly ApplicationDbContext _Context;
        private readonly ILogger<ProductInStockEventHandler> _logger;

        public ProductInStockEventHandler(ApplicationDbContext Context, ILogger<ProductInStockEventHandler> logger)
        {
            _Context = Context;
            _logger = logger;
        }

        public async Task Handle(ProductInStockCommands command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Buscando la existencia del objeto en la DB");
            ProductInStock? ExistStock = await _Context.Stocks.FirstOrDefaultAsync(x => x.ProductInStockId == command.ProductInStockId);

            if(ExistStock == null)
            {

                //Create Stock

                var newStock = new ProductInStock()
                {
                    ProductId = command.ProductId,
                    Stock = command.Stock,
                };

                _logger.LogInformation("Al no existir en la DB se ejecuta la creacion y guardado del stock ");
                await _Context.Stocks.AddAsync(newStock);
                await _Context.SaveChangesAsync();


            }
            else
            {
                //Update Stock
                _logger.LogInformation("El objeto existe en la DB, por lo cual se actualizan los datos");
                ExistStock.Stock = command.Stock;
                await _Context.SaveChangesAsync();
            }


        }

    }
}
