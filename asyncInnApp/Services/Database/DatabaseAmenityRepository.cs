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

    public async Task Add ( Amenity amenities )
    {
      _context.Amenities.Add(amenities);
      await _context.SaveChangesAsync();
    }

    public async Task<List<Amenity>> GetAll ( )
    {
      var result =  await _context.Amenities
        //Go get all of each Amenity's RoomAmenity
        .Include(a => a.RoomAmenity)
        //and also include each RoomAmenity Room
      .ThenInclude(r => r.RARoom)
      .ToListAsync();

      return result;
    }

    public async Task<Amenity> GetAmenity ( int id )
    {
      return await _context.Amenities.FindAsync(id);
    }

    public Task Remove ( int id )
    {
      throw new NotImplementedException();
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
