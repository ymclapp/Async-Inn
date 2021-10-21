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
    
    Task<Hotel> GetHotels ( int id );
    
    //Task alone ~= return void, but awaitable like the Task Add below
    Task Add ( Hotel hotels );
    Task<List<Hotel>> DeleteHotels ( int id );
    Task<bool> TryUpdate ( Hotel hotels );

  }
}
