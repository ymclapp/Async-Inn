using System;
using asyncInnApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Services
{
  public interface IAmenityRepository
  {
    Task<List<Amenity>> GetAll ( );
    Task<Amenity> GetAmenity ( int id );
    Task Add ( Amenity amenities );
    Task Remove ( int id );
    Task<bool> TryUpdate ( Amenity amenities );

    Task AddRoom ( int amenityId, int roomId );
  }
}
