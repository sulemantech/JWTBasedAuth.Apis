using JWTBasedAuth.Apis.JWT;
using JWTBasedAuth.Apis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTBasedAuth.Apis.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
       
        public LoginController(IJWTAutheticationManager autheticationManager, ILogger<LoginController> logger)
        {
            _authenticationManager = autheticationManager;
            _logger = logger;
        }
        private readonly ILogger<LoginController> _logger;
        private IJWTAutheticationManager _authenticationManager;


        [AllowAnonymous]
        [HttpPost(Name = "authenticate")]
        public IActionResult Authenticate([FromForm] UserLogin user)
        {
            var token =  _authenticationManager.Authenticate(user.UserName, user.Password);
            if(string.IsNullOrEmpty(token))
                return Unauthorized();
            return Ok(token);
        }

        [HttpGet("Name")]
        public string Get()
        {
            return  "{ \"Country:\"\"Germany\"}";
        }
    }
}