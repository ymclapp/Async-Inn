using System;
using asyncInnApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asyncInnApp.Models.DTO;

namespace asyncInnApp.Services
{
  public interface IAmenityRepository
  {
    Task<List<AmenityDTO>> GetAll ( );
    Task<Amenity> GetAmenity ( int id );
    Task Add ( Amenity amenities );
    Task Remove ( int id );
    Task RemoveAmenity ( int amenityId, int roomId);
    Task<bool> TryUpdate ( Amenity amenities );

    Task AddRoom ( int amenityId, int roomId );
    //Task AddAmenity ( int amenityId, int roomId );
  }
}
