using asyncInnApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Services
{
  public interface IHotelRepository
  {
    Task<List<Hotel>> GetAll();
    //Task<List<Hotels>> GetHotels ( int id );
    Task<Hotel> GetHotels ( int id );
    Task<List<Hotel>> PutHotels ( int id, Hotel hotels );
    Task<List<Hotel>> PostHotels ( Hotel hotels );
    Task<List<Hotel>> DeleteHotels ( int id );
    Task<List<Hotel>> HotelsExists ( int id );
  }
}
