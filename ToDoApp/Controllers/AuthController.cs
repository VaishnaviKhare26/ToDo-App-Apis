using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoApp.Model;
using ToDoApp.Services;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(JWTService jWTService, ToDoContext todocontext) : ControllerBase
    {
        private readonly JWTService jWTService = jWTService;

        private readonly ToDoContext _todocontext = todocontext;




        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel loginRequestModel)
        {
            var user = _todocontext.LoginCreds.SingleOrDefault(u => u.UserName == loginRequestModel.UserName);

            if (user != null && loginRequestModel.Password== user.Password)
            {
                var token = jWTService.GenerateToken(loginRequestModel.UserName);
                return Ok(new { token});
            }
            return Unauthorized();
            
        }

        
    }
}
