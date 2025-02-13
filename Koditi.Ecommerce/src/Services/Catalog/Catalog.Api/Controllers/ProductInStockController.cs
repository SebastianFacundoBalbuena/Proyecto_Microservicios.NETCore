using Catalog.Domain;
using Catalog.Services.EventHandlers.Commands;
using MediatR;
using Catalog.Service.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/ProductInStock")]
    [ApiController]
    public class ProductInStockController : ControllerBase
    {
        private readonly IMediator _Mediator;
        private readonly ProductInStockQueryServices _Context;
        public ProductInStockController(IMediator Mediator, ProductInStockQueryServices Context)
        {
            _Mediator = Mediator;
            _Context = Context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductInStock>>> GetAll()
        {
            List<ProductInStock> List =  await _Context.GetAll();
            return List;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProductInStockCommands command)
        {
            await _Mediator.Publish(command);

            return Ok("Se ha agregado/Actualizado correctamente");
        }
    }
}
