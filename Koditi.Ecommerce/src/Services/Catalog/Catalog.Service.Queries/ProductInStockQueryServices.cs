using Catalog.Domain;
using Catalog.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.Queries
{
    public class ProductInStockQueryServices
    {
        private readonly ApplicationDbContext _Context;

        public ProductInStockQueryServices(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        //Get all Stock
        public async Task<List<ProductInStock>> GetAll()
        {
            List<ProductInStock> ListStock =  _Context.Stocks.ToList();

            return ListStock;
        }
    }
}
