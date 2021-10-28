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
    [HttpPost("Register")]
    public async Task<IActionResult> Register ( RegisterData data )
    {
      return Ok();
    }
  }
}
