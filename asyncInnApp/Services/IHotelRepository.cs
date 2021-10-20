using asyncInnApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Services
{
  public interface IHotelRepository
  {
      Task<List<Hotels>> GetAll();
  }
}
