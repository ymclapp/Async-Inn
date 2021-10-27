using asyncInnApp.Data;
using asyncInnApp.Models;
using asyncInnApp.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Services.Database
{
  public class DatabaseHotelRepository : IHotelRepository
  {
    private readonly HotelsDBContext _context;
    public DatabaseHotelRepository(HotelsDBContext context)
    {
      _context = context;
    }

    public async Task Remove ( int id )
    {
      var hotels = await _context.Hotels.FindAsync(id);
      _context.Hotels.Remove(hotels);
      await _context.SaveChangesAsync();

      //return NoContent();
    }

    private void NoContent ( )
    {
      throw new NotImplementedException();
    }

    public async Task<List<HotelDTO>> GetAll ( )
    {
      var result = await _context.Hotels
        .Include(h => h.HotelRooms)
        //.ThenInclude(t => t.RoomId)
        .Select(hotel => new HotelDTO
        {
          ID = hotel.Id,
          Name = hotel.Name,
          StreetAddress = hotel.StreetAddress,
          City = hotel.City,
          State = hotel.State,
          Phone = hotel.Phone,
          //Rooms = hotel.Rooms,
        })
        .ToListAsync();

      return result;
    }

    public async Task<Hotel> GetHotel ( int id )
    {
      return await _context.Hotels.FindAsync(id);
      //throw new NotImplementedException();
    }

    //public async bool HotelsExists ( int id )
    //{
      //throw new NotImplementedException();
      //return _context.Hotels.Any(e => e.Id == id);
    //}

    public async Task Add ( Hotel hotels )
    {
      _context.Hotels.Add(hotels);
      await _context.SaveChangesAsync();
    }

    public async Task<bool> TryUpdate ( Hotel hotels )
    {
      _context.Entry(hotels).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!HotelsExists(hotels.Id))
        {
          //return NotFound();
          return false;
        }
        else
        {
          throw;
        }
      }

      return true;
    }

    private void NotFound ( )
    {
      throw new NotImplementedException();
    }

    private bool HotelsExists(int id)  
    {
    return _context.Hotels.Any(e => e.Id == id);

    }


  }
}
