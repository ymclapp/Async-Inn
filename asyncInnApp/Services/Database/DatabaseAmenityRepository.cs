using asyncInnApp.Data;
using asyncInnApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace asyncInnApp.Services.Database
{
  public class DatabaseAmenityRepository : IAmenityRepository
  {
    private readonly HotelsDBContext _context;
    public DatabaseAmenityRepository(HotelsDBContext context)
    {
      _context = context;
    }

    public async Task Add ( Amenity amenity )
    {
      _context.Amenities.Add(amenity);
      await _context.SaveChangesAsync();
    }

    public async Task AddRoom ( int amenityId, int roomId )
    {
      var roomAmenity = new RoomAmenity
      {
        AmenityId = amenityId,
        RoomId = roomId,
      };
      _context.RoomAmenities.Add(roomAmenity);
      await _context.SaveChangesAsync();
    }

    //need to finish
    public async Task RemoveRoom (int amenityId, int roomId)
    {
      var roomAmenity = await _context.RoomAmenities.FindAsync(amenityId, roomId);
    _context.RoomAmenities.Remove(roomAmenity);
      await _context.SaveChangesAsync ( );
    }
  public async Task<List<Amenity>> GetAll ( )
    {
      var result =  await _context.Amenities
        //Go get all of each Amenity's RoomAmenity
        .Include(a => a.RoomAmenities)
        //and also include each RoomAmenity Room
      .ThenInclude(r => r.Room)
      .ToListAsync();

      return result;
    }

    public async Task<Amenity> GetAmenity ( int id )
    {
      //return await _context.Amenities.FindAsync(id);
      var amenity = await _context.Amenities
        .Include(a => a.RoomAmenities)
        .ThenInclude(ra => ra.Room)
        .FirstOrDefaultAsync(a => a.Id == id);

      return await _context.Amenities.FindAsync(id);
    }

    public async Task Remove ( int id )
    {
      var amenities = await _context.Amenities.FindAsync(id);
      _context.Amenities.Remove(amenities);
      await _context.SaveChangesAsync();
    }

    public async Task RemoveAmenity ( int amenityId, int roomId )
    {
      var roomAmenity = await _context.RoomAmenities

        .FirstOrDefaultAsync(ar =>
          ar.AmenityId == amenityId &&
          ar.RoomId == roomId);

      _context.RoomAmenities.Remove(roomAmenity);
      await _context.SaveChangesAsync();
    }
    public async Task<bool> TryUpdate ( Amenity amenities )
    {
      _context.Entry(amenities).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AmenityExists(amenities.Id))
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
    private bool AmenityExists ( int id )
    {
      return _context.Amenities.Any(e => e.Id == id);
    }
  }
}
