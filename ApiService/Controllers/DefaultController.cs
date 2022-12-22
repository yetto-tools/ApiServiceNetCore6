using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers.V1
{
    [ApiController]
    [Route("")]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;

        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("[{}]: Acceded Default Controller", DateTime.UtcNow);

            var result = new { message = "Welcome To API's Service", version = "1.2" };

            _logger.LogInformation("[{}]: Result-> {}", DateTime.UtcNow, result);

            return Ok(result);
        }
    }
}
