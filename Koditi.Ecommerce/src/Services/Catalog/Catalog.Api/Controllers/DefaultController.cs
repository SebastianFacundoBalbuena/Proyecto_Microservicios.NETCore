using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {


        private readonly ILogger<DefaultController> _logger;

        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string  Get()
        {

            return "Running...";
        }
    }
}
