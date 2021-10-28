using System.Threading.Tasks;

namespace asyncInnApp.Models.Identity
{
  public interface IUserService
  {
    Task <ApplicationUser> Register ( RegisterData data );
  }
}
