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
  public class RoomsController : ControllerBase
  {
    private readonly HotelsDBContext _context;
    private readonly IRoomRepository rooms;

    public RoomsController ( IRoomRepository rooms, HotelsDBContext context )
    {
      this.rooms = rooms;
      _context = context;
    }

    //***************************************
    // GET: api/Rooms - context is gone
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRooms ( )
    {
      return await rooms.GetAll();
      //return await _context.Rooms.ToListAsync();  <<--moved to database room repository
    }

    // GET: api/Rooms/5 - context is gone
    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetRoom ( int id )
    {

      var room = await _context.Rooms.FindAsync(id);
      if (this.rooms == null)
      {
        return NotFound();
      }

      return room;
    }


    //**********************************
    // PUT: api/Rooms/5 - context is gone
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoom ( int id, Room rooms )
    {
      if (id != rooms.Id)
      {
        return BadRequest();
      }
      if (!await this.rooms.TryUpdate(rooms))
      {
        return NotFound();
      }
      return NoContent();
    }

      //  _context.Entry(room).State = EntityState.Modified;

      //try
      //{
      //  await _context.SaveChangesAsync();
      // }
      // catch (DbUpdateConcurrencyException)
      // {
      //   if (!RoomExists(id))
      // {
      //          return NotFound();
      //    }
      //  else
      //{
      //  throw;
      //}
      //}

      //return NoContent();

    //}
    //********************
    // POST: api/Rooms - context is gone
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Room>> PostRoom ( Room rooms )
    {
      //_context.Rooms.Add(room);
      //await _context.SaveChangesAsync();
      await this.rooms.Add(rooms);
      return CreatedAtAction("GetRoom", new { id = rooms.Id }, rooms);
    }

    //************************************
    // DELETE: api/Rooms/5 - context is gone
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom ( int id )
    {
      await this.rooms.Remove(id);
      //var room = await _context.Rooms.FindAsync(id);
      if (rooms == null)
      {
        return NotFound();
      }

      //_context.Rooms.Remove(room);
      //await _context.SaveChangesAsync();

      return NoContent();
    }

    //POST:  api/Rooms/5/Amenities/17
    [HttpPost]
    [Route("{id}/Rooms/{roomId}/Amenities/{amenityId}")]
    public async Task<IActionResult> AddRoomToAmenity (int id, int amenityId)
    {
      await rooms.AddAmenity(id, amenityId);
      return NoContent();
    }

    //DELETE:  api/Rooms/5/Amenities/17
    [HttpDelete]
    [Route("{id}/Rooms/{roomId}/Amenities/{amenityId}")]
    public async Task<IActionResult> RemoveFromAmenity ( int id, int amenityId )
    {
      await rooms.RemoveRoom(id, amenityId);  //need to finish in the DatabaseAmenityRepository
      return NoContent();
    }
  }


       // private bool RoomExists(int id)
        //{
          //  return _context.Rooms.Any(e => e.Id == id);
       // }
    
}
