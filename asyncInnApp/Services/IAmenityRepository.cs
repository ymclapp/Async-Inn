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
  }
}
