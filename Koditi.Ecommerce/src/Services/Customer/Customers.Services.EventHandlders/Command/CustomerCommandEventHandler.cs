using MediatR;

namespace Customers.Services.EventHandlders.Command
{
    public class CustomerCommandEventHandler : INotification
    {
        //Properties

        public int customerId {  get; set; }

        public string Name {  get; set; }
    }

    public class CustomerDeleteCommand : INotification
    {
        public int customerId { get; set; }
    }
}
