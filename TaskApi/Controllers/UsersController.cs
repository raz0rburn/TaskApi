using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Helpers;
using TaskApi.Models;
using TaskApi.Services;
using Microsoft.EntityFrameworkCore;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            try
            {
                var response = await _userService.Register(userModel);
                if (response == null)
                {
                    return BadRequest(new { message = "Didn't register!" });
                }
                return Ok(response);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { message = ex.Message + "DB request error!" });
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
