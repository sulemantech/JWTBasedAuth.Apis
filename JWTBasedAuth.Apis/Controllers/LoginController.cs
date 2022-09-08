using JWTBasedAuth.Apis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTBasedAuth.Apis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
       
        private readonly ILogger<WeatherForecastController> _logger;

        public LoginController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "authenticate")]
        public IActionResult Authenticate([FromForm] UserLogin user)
        {
            return Ok();
        }
    }
}