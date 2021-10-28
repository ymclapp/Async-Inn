using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Models.Identity
{
  public class AspNetCoreIdentityUserService : IUserService  //IdentityUserService in steps, but you can name whatever
  {
    private readonly UserManager<ApplicationUser> userManager;

    public AspNetCoreIdentityUserService(UserManager<ApplicationUser> userManager)
    {
      this.userManager = userManager;
    }
    public async Task Register ( RegisterData data )
    {
      var user = new ApplicationUser
      {
        Email = data.Email,
        UserName = data.Username,
        //Password = data.Password,  //NOOOOOOOOOO
      };
      await userManager.CreateAsync(user, data.Password );
    }
  }
}
