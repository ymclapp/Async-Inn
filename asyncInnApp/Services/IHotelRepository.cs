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
    
    Task<Hotel> GetHotel ( int id );
    
    //Task alone ~= return void, but awaitable like the Task Add below
    Task Add ( Hotel hotels );

    /// <summary>
    /// Try to delete, but return false if id not found
    /// </summary>
    /// <param name="id">The id to delete</param>
    /// <returns>Task with value of true if delete worked; fale if not found</returns>
    Task Remove ( int id );
    Task<bool> TryUpdate ( Hotel hotels );

  }
}
