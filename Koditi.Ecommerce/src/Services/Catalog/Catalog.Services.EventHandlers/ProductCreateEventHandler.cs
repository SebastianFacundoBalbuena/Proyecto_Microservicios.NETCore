using Catalog.Persistence.DataBase;
using Catalog.Services.EventHandlers.Commands;
using Catalog.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Catalog.Services.EventHandlers
{
    public class ProductCreateEventHandler : INotificationHandler<ProductCreateCommand>
    {
        private readonly ApplicationDbContext _Context;
        private readonly ILogger<ProductCreateEventHandler> _logger;

        public ProductCreateEventHandler(ApplicationDbContext Context, ILogger<ProductCreateEventHandler> logger)
        {
            _Context = Context;
            _logger = logger;
        }

        public async Task Handle(ProductCreateCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Obteniendo el objeto de la base de datos");
            Product? getCommand = await _Context.Products.FirstOrDefaultAsync(x=>x.ProductId == command.ProductId);

            if(getCommand == null)
            {
                //Create
                Product newCommand = new Product()
                {
                    Name = command.Name,
                    Description = command.Description,
                    Price = command.Price,
                };

                _logger.LogInformation("El objeto al no existir en la DB fue creado y almacenado");
                await _Context.Products.AddAsync(newCommand);
                await _Context.SaveChangesAsync();

            }
            else
            {
                //Update 
                _logger.LogInformation("El objeto fue hayado en la DB por lo cual se actualizaran los datos");
                getCommand.Name = command.Name;
                getCommand.Description = command.Description;
                getCommand.Price = command.Price;

                 await _Context.SaveChangesAsync();
            }
        }
    }
}
