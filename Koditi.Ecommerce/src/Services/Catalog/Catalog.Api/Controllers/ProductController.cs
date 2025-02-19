using Catalog.Domain;
using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Catalog.Services.EventHandlers.Commands;
using MediatR;

namespace Catalog.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductQueryService _Context;
        private readonly IMediator _Mediator;
        public ProductController(ProductQueryService Context, IMediator Mediator)
        {
            _Context = Context;
            _Mediator = Mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var ListAll = await _Context.GetAll();

            return Ok(ListAll);
        }

        [HttpGet("GetId")]
        public async Task<ActionResult<Product>>GetId(int Id)
        {
            Product? product = await _Context.GetId(Id);

            if(product != null)
            {
                return Ok(product);
            }

            return NotFound("El producto no se ha encontrado");
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProductCreateCommand command)
        {
            await _Mediator.Publish(command);

            return Ok("Se ha almacenado correctamente");
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(ProductDeleteCommand command)
        {
            try
            {
                await _Mediator.Publish(command);

                return Ok("Se ha eliminado correctamente");
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(ex.Message);
            }

            
        }
        
    }
}
