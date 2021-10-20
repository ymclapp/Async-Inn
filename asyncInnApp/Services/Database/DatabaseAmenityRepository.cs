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
    public async Task<List<Amenity>> GetAll ( )
    {
      return await _context.Amenities.ToListAsync();
    }
  }
}
