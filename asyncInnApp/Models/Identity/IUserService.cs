using System.Threading.Tasks;

namespace asyncInnApp.Models.Identity
{
  public interface IUserService
  {
    Task Register ( RegisterData data );
  }
}
