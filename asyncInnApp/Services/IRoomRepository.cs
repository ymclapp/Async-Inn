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

    Task Remove ( int id );

    Task RemoveAmenity ( int roomId, int amenityId );
    //Task RemoveRoom ( int amenityId, int roomId );
    Task<bool> TryUpdate ( Room rooms );
    Task AddAmenity ( int roomId, int amenityId );

  }
}
