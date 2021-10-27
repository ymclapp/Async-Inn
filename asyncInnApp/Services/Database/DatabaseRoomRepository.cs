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
  public class DatabaseRoomRepository : IRoomRepository
  {
    private readonly HotelsDBContext _context;
    public DatabaseRoomRepository(HotelsDBContext context)
    {
      _context = context;
    }

    public async Task Add ( Room room )
    {
      _context.Rooms.Add(room);
      await _context.SaveChangesAsync();
    }

    public async Task AddAmenity ( int roomId, int amenityId )
    {
      var roomAmenity = new RoomAmenity
      {
        RoomId = roomId,
        AmenityId = amenityId,
      };
      _context.RoomAmenities.Add(roomAmenity);
      await _context.SaveChangesAsync();
    }

    public async Task<List<RoomDTO>> GetAll()
    {
      //return await _context.Rooms.ToListAsync();
      var result = await _context.Rooms
        .Include(r => r.RoomAmenities)
        .ThenInclude(a => a.Amenity)
        .Select(room => new RoomDTO
        {
          ID = room.Id,
          Name = room.Name,
          Layout = room.Layout,
        })
        .ToListAsync();

      return result;
    }

    public async Task<Room> GetRoom ( int id )
    {
      var room = await _context.Rooms
      .Include(r => r.RoomAmenities)
      .ThenInclude(ra => ra.Amenity)
      .FirstOrDefaultAsync(r => r.Id == id);

      return await _context.Rooms.FindAsync(id);

    }

    public async Task Remove ( int id )
    {
      var rooms = await
        _context.Rooms.FindAsync(id);
      _context.Rooms.Remove(rooms);
      await _context.SaveChangesAsync();
    }

    public async Task RemoveAmenity(int roomId, int amenityId)
    {
      var roomAmenity = await _context.RoomAmenities

        .FirstOrDefaultAsync(ar =>
          ar.RoomId == roomId &&
          ar.AmenityId == amenityId);
      _context.RoomAmenities.Remove(roomAmenity);
      await _context.SaveChangesAsync();
    }

    
    public async Task<bool> TryUpdate ( Room room )
    {
      _context.Entry(room).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RoomExists(room.Id))
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
