using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public async Task<ApplicationUser> Register ( RegisterData data, ModelStateDictionary modelState )
    {
      var user = new ApplicationUser
      {
        Email = data.Email,
        UserName = data.Username,
        //Password = data.Password,  //NOOOOOOOOOO
      };
      var result = await userManager.CreateAsync(user, data.Password );
      if(result.Succeeded)
      {
        return user;
      }

      foreach (var error in result.Errors)
      {
        var errorKey =
            error.Code.Contains("Password") ? nameof(data.Password) :
            error.Code.Contains("Email") ? nameof(data.Email) :
            error.Code.Contains("UserName") ? nameof(data.Username) :
            "";
        modelState.AddModelError(errorKey, error.Description);
      }
      return null;
    }

  }
}
