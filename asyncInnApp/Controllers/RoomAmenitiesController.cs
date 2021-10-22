using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asyncInnApp.Data;
using asyncInnApp.Models;

namespace asyncInnApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAmenitiesController : ControllerBase
    {
        private readonly HotelsDBContext _context;

        public RoomAmenitiesController(HotelsDBContext context)
        {
            _context = context;
        }

        // GET: api/RoomAmenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomAmenity>>> GetRoomAmenities()
        {
            return await _context.RoomAmenities.ToListAsync();
        }

        // GET: api/RoomAmenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomAmenity>> GetRoomAmenity(int id)
        {
            var roomAmenity = await _context.RoomAmenities.FindAsync(id);

            if (roomAmenity == null)
            {
                return NotFound();
            }

            return roomAmenity;
        }

        // PUT: api/RoomAmenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomAmenity(int id, RoomAmenity roomAmenity)
        {
            if (id != roomAmenity.RoomId)
            {
                return BadRequest();
            }

            _context.Entry(roomAmenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomAmenityExists(id))
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

        // POST: api/RoomAmenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomAmenity>> PostRoomAmenity(RoomAmenity roomAmenity)
        {
            _context.RoomAmenities.Add(roomAmenity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomAmenityExists(roomAmenity.RoomId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoomAmenity", new { id = roomAmenity.RoomId }, roomAmenity);
        }

        // DELETE: api/RoomAmenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomAmenity(int id)
        {
            var roomAmenity = await _context.RoomAmenities.FindAsync(id);
            if (roomAmenity == null)
            {
                return NotFound();
            }

            _context.RoomAmenities.Remove(roomAmenity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomAmenityExists(int id)
        {
            return _context.RoomAmenities.Any(e => e.RoomId == id);
        }
    }
}
