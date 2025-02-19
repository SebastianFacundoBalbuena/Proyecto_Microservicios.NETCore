using Catalog.Persistence.DataBase;
using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Catalog.Services.EventHandlers.Commands;
using Microsoft.Extensions.Logging;



namespace Catalog.Services.EventHandlers
{
    public class ProductDeleteEventHandler : INotificationHandler<ProductDeleteCommand>
    {
        private readonly ApplicationDbContext _Context;
        private readonly ILogger<ProductDeleteEventHandler> _logger;    
        public ProductDeleteEventHandler(ApplicationDbContext Context,ILogger<ProductDeleteEventHandler> logger)
        {
            _Context = Context;
            _logger = logger;
        }
        public async Task Handle(ProductDeleteCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Buscando el id del producto");
            Product? product = await _Context.Products.FirstOrDefaultAsync(x=>x.ProductId == command.ProductId);

            if(product != null)
            {
                _Context.Products.Remove(product);
                await _Context.SaveChangesAsync();
                _logger.LogInformation("Producto eliminado correctamente");

            }
            else
            {
                _logger.LogError("No se ha encontrado el id del producto en la DB");
                throw new KeyNotFoundException("No se ha encontrado el id del producto");
            }




          
        }
    }
}
