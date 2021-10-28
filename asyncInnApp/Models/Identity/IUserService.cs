using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace asyncInnApp.Models.Identity
{
  public interface IUserService
  {
    Task <ApplicationUser> Register ( RegisterData data, ModelStateDictionary modelState );
  }
}
