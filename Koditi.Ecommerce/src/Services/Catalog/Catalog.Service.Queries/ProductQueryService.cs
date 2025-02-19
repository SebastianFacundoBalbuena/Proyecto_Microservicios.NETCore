using Catalog.Domain;
using Catalog.Persistence.DataBase;
using Catalog.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Catalog.Service.Queries
{
    public class ProductQueryService 
    {
        private readonly ApplicationDbContext _Context;
        private readonly ILogger<ProductQueryService> _logger;  
        public ProductQueryService(ApplicationDbContext Context, ILogger<ProductQueryService> logger)
        {
            _Context = Context;
            _logger = logger;
        }

        public async Task<List<Product>> GetAll()
        {
            _logger.LogInformation("ProductQueryService iniciado");

            List<Product>? ListProduct = await _Context.Products.Include(x=>x.Stock).ToListAsync();

            _logger.LogInformation($"ProductQueryService finalizado y trajo los datos {ListProduct}");
            return ListProduct;

        }

        public async Task<Product>GetId(int Id)
        {
            Product? product = _Context.Products.FirstOrDefault(x=>x.ProductId == Id);

            return product;
        }
    }
}
