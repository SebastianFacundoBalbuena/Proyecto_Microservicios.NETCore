using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Services.EventHandlers.Commands
{
    public  class ProductInStockCommands : INotification
    {
        public int ProductInStockId { get; set; }

        public int ProductId { get; set; }

        public int Stock {  get; set; }
    }
}
