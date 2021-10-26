using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asyncInnApp.Data;
using asyncInnApp.Models;
using asyncInnApp.Services;

namespace asyncInnApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelsDBContext _context;  //we are asking for a dependency
        private readonly IHotelRepository hotels;

        public HotelsController(IHotelRepository hotels, HotelsDBContext context) //we are responding with the dependency.  Leave the HotelsDBContext for Rooms and Amenities since the HotelsDBContext is the only one for the database.
        {
          this.hotels = hotels;
          _context = context;
        }

        // GET: api/Hotels - context is gone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {
          return await hotels.GetAll();

          //return await _context.Hotels.ToListAsync(); <<--went to DatabaseHotelRepository and replaced with the above
        }

        // GET: api/Hotels/5 - context is gone
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
      //var hotels = await _context.Hotels.FindAsync(id);
      var hotel = await this.hotels.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5 - context is gone
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotels(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

           // _context.Entry(hotels).State = EntityState.Modified;

           // try
           // {
            //    await _context.SaveChangesAsync();
            //}
           // catch (DbUpdateConcurrencyException)
            //{
                //if (!HotelsExists(id))
                //{
                //   return NotFound();
                //}
                //else
            //    {
            //        throw;
            //    }
            //}
            if(!await this.hotels.TryUpdate(hotel))
            {
              return NotFound();
            }
            return NoContent();
           }

        // POST: api/Hotels - context is gone
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotels(Hotel hotel)
        {
          await this.hotels.Add(hotel);
      //_context.Hotels.Add(hotels);  <<--moved to DatabaseHotelRepository
      //await _context.SaveChangesAsync();  <<--moved to DatabaseHotelRepository

      return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5 - context is gone
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotels(int id)
        {
      await this.hotels.Remove(id);
      //var hotels = await _context.Hotels.FindAsync(id);<<--moved to DatabaseHotelRepository
      if (hotels == null)
            {
                return NotFound();
            }
      //_context.Hotels.Remove(hotels);<<--moved to DatabaseHotelRepository
      //await _context.SaveChangesAsync();<<--moved to DatabaseHotelRepository

      return NoContent();
        }

        //private bool HotelsExists(int id)  <<--moved to databasehotelrepository
        //{
          //return _context.Hotels.Any(e => e.Id == id);
      //return await hotels.HotelsExists(int id);
    //}
    }
}
