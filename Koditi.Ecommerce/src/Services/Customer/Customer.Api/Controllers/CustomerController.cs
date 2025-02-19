using Customer.Services.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Customer.Services.EventHandlders;
using Customers.Services.EventHandlders.Command;
using MediatR;

namespace Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerServicesQuery _context;
        private readonly IMediator _mediator;

        public CustomerController(CustomerServicesQuery context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }   

        [HttpGet]
        public async Task<ActionResult<Domain.Customer>>GetId(int Id)
        {
          
                Domain.Customer? customer = await _context.GetId(Id);

                if(customer != null)
                {
                    return Ok(customer);
                }
                else
                {
                    return NotFound("No se ha encontrado al cliente");
                }
           
            
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Domain.Customer>>> GetAll()
        {
            return Ok(await _context.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Post(CustomerCommandEventHandler command)
        {
            await _mediator.Publish(command);

            return NoContent();
        }
    }
}
