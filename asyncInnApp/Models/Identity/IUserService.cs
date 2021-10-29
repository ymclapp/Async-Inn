using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace asyncInnApp.Models.Identity
{
  public interface IUserService
  {
    Task <UserDto> Register ( RegisterData data, ModelStateDictionary modelState );
    Task <UserDto>Authenticate ( LoginData data );
    Task<UserDto> GetUser ( ClaimsPrincipal user );
  }
}
