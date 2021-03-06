using asyncInnApp.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Controllers
{
  [Authorize(Roles = "District Manager")]
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
      this.userService = userService;
    }
    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register ( RegisterData data )
    {
      var user = await userService.Register(data, this.ModelState);
      if (user == null)
        return BadRequest(new ValidationProblemDetails(ModelState));

      return user;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>> Login(LoginData data)
    {
      var user = await userService.Authenticate(data);

      if (user == null)
        return Unauthorized();

      return user;
    }

    //Can't access this if you are not signed in
    [Authorize]  //can be put on any controller or action
    [HttpGet("[action]")]
    public async Task<ActionResult<UserDto>> Self()//can I get information about myself
    {
      var user = await userService.GetUser(this.User);

      if (User == null)
        return NotFound();

      return user;
    }
  }
}
