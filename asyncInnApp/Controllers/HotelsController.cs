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
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
          return await hotels.GetAll();

          //return await _context.Hotels.ToListAsync(); <<--went to DatabaseHotelRepository and replaced with the above
        }

        // GET: api/Hotels/5 - context is gone
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotels(int id)
        {
      //var hotels = await _context.Hotels.FindAsync(id);
      var hotels = await this.hotels.GetHotels(id);
            if (hotels == null)
            {
                return NotFound();
            }

            return hotels;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotels(int id, Hotel hotels)
        {
            if (id != hotels.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels - ****has error at add that it isn't implemented (per Postman)****
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotels(Hotel hotels)
        {
          await this.hotels.Add(hotels);
      //_context.Hotels.Add(hotels);  <<--moved to DatabaseHotelRepository
      //await _context.SaveChangesAsync();  <<--moved to DatabaseHotelRepository

      return CreatedAtAction("GetHotels", new { id = hotels.Id }, hotels);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotels(int id)
        {
            var hotels = await _context.Hotels.FindAsync(id);
            if (hotels == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelsExists(int id)
        {
          return _context.Hotels.Any(e => e.Id == id);
      //return await hotels.HotelsExists(int id);
    }
    }
}
