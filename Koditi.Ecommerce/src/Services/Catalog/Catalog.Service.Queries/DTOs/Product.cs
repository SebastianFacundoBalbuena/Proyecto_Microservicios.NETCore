﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.Queries.DTOs
{
    public class ProductDTOs
    {
        //Properties

        [Key]
        public int ProductId {  get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public ProductInStockDTOs Stock { get; set; }
    }
}
