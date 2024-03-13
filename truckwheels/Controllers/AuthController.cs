using Microsoft.AspNetCore.Mvc;
using truckwheels.Services;

namespace truckwheels.Controllers
{

   [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "juliana" && password == "123456")
            {
                var token = TokensService.GenerateToken(new Model.Employee());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}
