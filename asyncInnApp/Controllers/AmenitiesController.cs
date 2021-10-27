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
using asyncInnApp.Models.DTO;

namespace asyncInnApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly HotelsDBContext _context;
        private readonly IAmenityRepository amenities;

        public AmenitiesController(IAmenityRepository amenities, HotelsDBContext context)
        {
            this.amenities = amenities;
            _context = context;
        }

    //******************************************
        // GET: api/Amenities - context is gone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities()
        {
          return await amenities.GetAll();
        }

    //***********************************
        // GET: api/Amenities/5 - context is gone
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            var amenity = await this.amenities.GetAmenity(id);

            if (amenity == null)
            {
              return NotFound();
            }

            return amenity;
        }

    //****************************************
        // PUT: api/Amenities/5 - context is gone
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
            if (id != amenity.Id)
            {
                return BadRequest();
            }
            if(!await this.amenities.TryUpdate(amenity))
            {
                return NotFound();
            }

            return NoContent();
        }


    //*********************************************************************
        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
        {
            await this.amenities.Add(amenity);

            return CreatedAtAction("GetAmenity", new { id = amenity.Id }, amenity);
        }

    //*********************************************************************
    // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity == null)
            {
                  return NotFound();
            }

            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    //*********************************************************************
    //POST:  api/Amenities/5/Rooms/17
        [HttpPost]
        [Route("{id}/Rooms/{roomId}")]
        public async Task<IActionResult> AddAmenityToRoom ( int id, int roomId )
        {
              await this.amenities.AddRoom(id, roomId);
              return NoContent();
        }

    //*********************************************************************
    //DELETE:  api/Amenities/5/Rooms/17
        [HttpDelete]
        [Route("{id}/Rooms/{roomId}")]
        public async Task<IActionResult> RemoveFromRoom(int id, int roomId)
        {
              await amenities.RemoveAmenity(id, roomId);  
              return NoContent();
        }
    }
}
