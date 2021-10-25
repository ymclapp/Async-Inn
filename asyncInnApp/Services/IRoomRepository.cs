using asyncInnApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Services
{
  public interface IRoomRepository
  {
    Task<List<Room>> GetAll ( );

    Task<Room> GetRoom ( int id );
    Task Add ( Room rooms );
    /// <summary>
    /// Try to delete, but return false if id not found
    /// </summary>
    /// <param name="id">The id to delete</param>
    /// <returns>True if delete worked; fale if not found</returns>
    Task Remove ( int id );
    Task<bool> TryUpdate ( Room rooms );

  }
}
