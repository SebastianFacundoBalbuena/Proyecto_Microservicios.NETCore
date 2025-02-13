﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Services.EventHandlers.Commands
{
    public class ProductCreateCommand : INotification
    {
        public int ProductId {  get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
