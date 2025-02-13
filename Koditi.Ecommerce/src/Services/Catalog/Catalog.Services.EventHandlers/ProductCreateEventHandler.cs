using Catalog.Persistence.DataBase;
using Catalog.Services.EventHandlers.Commands;
using Catalog.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Services.EventHandlers
{
    public class ProductCreateEventHandler : INotificationHandler<ProductCreateCommand>
    {
        private readonly ApplicationDbContext _Context;

        public ProductCreateEventHandler(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task Handle(ProductCreateCommand command, CancellationToken cancellationToken)
        {
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

                await _Context.Products.AddAsync(newCommand);
                await _Context.SaveChangesAsync();

            }
            else
            {
                //Update 
                getCommand.Name = command.Name;
                getCommand.Description = command.Description;
                getCommand.Price = command.Price;

                 _Context.SaveChanges();
            }
        }
    }
}
