using MediatR;

namespace Customers.Services.EventHandlders.Command
{
    public class CustomerCommandEventHandler : INotification
    {
        //Properties

        public int ClientId {  get; set; }

        public string Name {  get; set; }
    }
}
