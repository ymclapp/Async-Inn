using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asyncInnApp.Models;
using asyncInnApp.Models.DTO;

namespace asyncInnApp.Services
{
  public interface IHotelRoomRepository
  {
    Task<List<CreateHotelRoomData>> GetHotelRooms ( );
    Task<HotelRoom> GetHotelRoom ( int id );
    Task Add ( HotelRoom hotelRooms );
    Task Remove ( int id );
    Task RemoveRoom ( int roomId, int hotelId );
    Task<bool> TryUpdate ( HotelRoom hotelRooms );
  }
}
