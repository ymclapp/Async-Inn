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
    public async Task<List<Hotels>> GetAll ( )
    {
      return await _context.Hotels.ToListAsync();
    }


  }
}
