using ApiService.Domain.Services.Actions;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers.V2
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IPersonServiceAction _personServiceAction;
        public TestController(ILogger<TestController> logger, IPersonServiceAction personServiceAction)
        {
            _logger = logger;
            _personServiceAction = personServiceAction;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
        {
            try
            {
                var people = await _personServiceAction.GetPeopleAll();
                if (people == null) return NoContent();
                return Ok(people);
            }
            catch (Exception ex)
            {
                _logger.LogError("[{}] {} ", DateTime.UtcNow, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
