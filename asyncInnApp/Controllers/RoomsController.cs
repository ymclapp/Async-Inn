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
    }

    // GET: api/Rooms/5 - context is gone
    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetRoom ( int id )
    {

      var room = await this.rooms.GetRoom(id);
      if (room == null)
      {
        return NotFound();
      }

      return room;
    }


    //**********************************
    // PUT: api/Rooms/5 - context is gone
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoom ( int id, Room room )
    {
      if (id != room.Id)
      {
        return BadRequest();
      }
      if (!await this.rooms.TryUpdate(room))
      {
        return NotFound();
      }
      return NoContent();
    }


    //********************
    // POST: api/Rooms - context is gone
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("{id}")]
    public async Task<ActionResult<Room>> PostRoom ( Room room )
    {
      await this.rooms.Add(room);
      return CreatedAtAction("GetRoom", new { id = room.Id }, room);
    }

    //************************************
    // DELETE: api/Rooms/5 - context is gone
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom ( int id )
    {
      await this.rooms.Remove(id);

      if (rooms == null)  //<<--this is wrong - fix
      {
        return NotFound();
      }

      return NoContent();
    }

    //POST:  api/Rooms/5/Amenities/17
    [HttpPost]
    [Route("{id}/Amenities/{amenityId}")]
    public async Task<IActionResult> AddRoomToAmenity ( int id, int amenityId )
    {
      await rooms.AddAmenity(id, amenityId);
      return NoContent();
    }

    //DELETE:  api/Rooms/5/Amenities/17
    [HttpDelete]
    [Route("{id}/Amenities/{amenityId}")]
    public async Task<IActionResult> RemoveFromAmenity ( int id, int amenityId )
    {
      await rooms.RemoveAmenity(id, amenityId);  //need to finish in the DatabaseAmenityRepository
      return NoContent();
    }
  }
}


