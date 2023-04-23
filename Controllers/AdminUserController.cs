using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Numerics;

namespace GameX1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : BaseController
    {

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(HttpStatusCode.NotImplemented);
        }


        [HttpPost("login")]
        public IActionResult LogIn(string username, string password)
        {
            //Check is username & password exists
            using (var context = new DataContext())
            {
                var user = context.AdminUser
                                .Where(x => x.Username.Equals(username) && x.Password.Equals(password))
                                .SingleOrDefault();

                if (user.AdminUserId > 0)
                    return Ok(HttpStatusCode.OK);
                else
                    return BadRequest(new { message = "Login Failed!" });
            }
        }
    }
}
