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
    [Route("api/Hotels/{hotelId}/Rooms")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly HotelsDBContext _context;

        public HotelRoomsController(HotelsDBContext context)
        {
      //this.hotelRooms = hotelRooms;
      _context = context;
        }

        // GET: api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms(int hotelId, int roomId)
        {
            return await _context.HotelRooms
                  .Where(hr => hr.HotelId == hotelId)//hotel is like students in transcripts
                  .Include(hr => hr.Hotel)
                  .Include(hr => hr.Room)//<<--this doesn't seem right - roomnumber?
                  .ThenInclude(a => a.RoomAmenities)
                  .ToListAsync();
        }

        // GET: api/HotelRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int id)
        {
      var hotelRoom = await _context.HotelRooms
          .Include(h => h.Hotel)
          //.Include(h => h.RoomNumber)
          .FirstOrDefaultAsync(h => h.HotelId == id);

            if (hotelRoom == null || hotelRoom.HotelId !=hotelId)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRoom(int id, HotelRoom hotelRoom)
        {
            if (id != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            _context.Entry(hotelRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelRoomExists(id))
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

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
       // public async Task<ActionResult<HotelRoom>> PostHotelRoom(int id, CreateHotelRoomData createData)
       // {
      //      _context.HotelRooms.Add(id);
       //     try
       //     {
      //          await _context.SaveChangesAsync();
       //     }
       //     catch (DbUpdateException)
       //if (HotelRoomExists(id))
       //         {
        //            return Conflict();
         //       }
         //       else
         //       {
         //           throw;
         //       }
        //   }

         //   return CreatedAtAction("GetHotelRoom", new { id = roomId }, hotelRoom);
       // }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelRoom(int id)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.RoomNumber == id);
        }
    }
}
