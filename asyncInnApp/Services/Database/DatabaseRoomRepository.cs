using asyncInnApp.Data;
using asyncInnApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Services.Database
{
  public class DatabaseRoomRepository : IRoomRepository
  {
    private readonly HotelsDBContext _context;
    public DatabaseRoomRepository(HotelsDBContext context)
    {
      _context = context;
    }

    public async Task Add ( Room rooms )
    {
      _context.Rooms.Add(rooms);
      await _context.SaveChangesAsync();
    }

    public async Task<List<Room>> GetAll()
    {
      return await _context.Rooms.ToListAsync();
    }

    public async Task<Room> GetRoom ( int id )
    {
      return await _context.Rooms.FindAsync(id);
    }

    public async Task Remove ( int id )
    {
      var rooms = await _context.Rooms.FindAsync(id);
      _context.Rooms.Remove(rooms);
      await _context.SaveChangesAsync();
    }

    public async Task<bool> TryUpdate ( Room rooms )
    {
      _context.Entry(rooms).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RoomExists(rooms.Id))
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
  private bool RoomExists ( int id )
  {
    return _context.Rooms.Any(e => e.Id == id);
  }
}
}
