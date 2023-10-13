using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InTime.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthContorller : ControllerBase
    {
        [HttpPost("register")]
        public Task<ActionResult> Register()
        {

        }

        [HttpPost("login")]
        public Task<ActionResult> Login() 
        {

        }

        [HttpPost("refresh")]
        public Task<ActionResult> Refresh()
        {

        }

        [HttpPost("logout")]
        public Task<ActionResult> LogOut()
        {

        }
    }
}