using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ApiService.Domain.Services.Actions;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers.V1
{
    //    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserServiceAction _userServiceAction;

        public UserController(ILogger<UserController> logger, IUserServiceAction userServiceAction)
        {
            _logger = logger;
            _userServiceAction = userServiceAction;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAll()
        {
            try
            {
                var users = await _userServiceAction.GetUsersAll();
                if (users == null) return NoContent();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError("[{}] {} ", DateTime.UtcNow, ex.Message);
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                var user = await _userServiceAction.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError("[{}] {} ", DateTime.UtcNow, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}")]
        [DisplayName("Verificate")]
        public async Task<IActionResult> VericateUser([Required] string id, [FromQuery] string password)
        {
            _logger.LogInformation("user: {}  password:{}", id, password);
            try
            {
                var user = await _userServiceAction.VerificatePassword(id, password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError("[{}] {} ", DateTime.UtcNow, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}