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
    public async Task<List<Room>> GetAll()
    {
      return await _context.Rooms.ToListAsync();
    }
  }
}
