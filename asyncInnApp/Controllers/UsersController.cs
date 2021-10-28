using asyncInnApp.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Controllers
{
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
    public async Task<IActionResult> Register ( RegisterData data )
    {
      var user = await userService.Register(data);
      if (user == null)
        return BadRequest();

      return Ok(user);
    }
  }
}
