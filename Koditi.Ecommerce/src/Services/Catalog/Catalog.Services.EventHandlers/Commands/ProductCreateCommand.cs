using MediatR;

namespace Catalog.Services.EventHandlers.Commands
{
    public class ProductCreateCommand : INotification
    {
        public int ProductId {  get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }

    public class ProductDeleteCommand : INotification
    {
        public int ProductId { get; set; }
    }
}
