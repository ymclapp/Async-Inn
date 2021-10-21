using asyncInnApp.Data;
using asyncInnApp.Models;
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

    public Task<List<Hotel>> DeleteHotels ( int id )
    {
      throw new NotImplementedException();
    }

    public async Task<List<Hotel>> GetAll ( )
    {
      return await _context.Hotels.ToListAsync();
    }

    public async Task<Hotel> GetHotels ( int id )
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

    public Task<List<Hotel>> PutHotels ( int id, Hotel hotels )
    {
      throw new NotImplementedException();
    }
  }
}
