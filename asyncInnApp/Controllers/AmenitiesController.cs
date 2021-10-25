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
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
          return await amenities.GetAll();

      //return await _context.Amenities.ToListAsync();
        }

    //***********************************
        // GET: api/Amenities/5 - context is gone
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
      var amenity = await _context.Amenities.FindAsync(id);
      //var amenity = await this.GetAmenities();
        //.Include(a => a.RoomAmenities)
        //.ThenInclude(ra => ra.RARoom)
        //.FindAsync(id);

            if (amenities == null)
            {
                return NotFound();
            }

      return amenity;
    }

    //****************************************
        // PUT: api/Amenities/5 - context is gone
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenities)
        {
            if (id != amenities.Id)
            {
                return BadRequest();
            }
            if(!await this.amenities.TryUpdate(amenities))
            {
              return NotFound();
            }

 //           _context.Entry(amenity).State = EntityState.Modified;

   //         try
     //      {
       //         await _context.SaveChangesAsync();
        //    }
           // catch (DbUpdateConcurrencyException)
          //  {
          //      if (!AmenityExists(id))
           //     {
            //        return NotFound();
           //     }
          //      else
          //      {
           //         throw;
            //    }
           // }

            return NoContent();
        }


    //*********************************************************************
        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenities)
        {
      // _context.Amenities.Add(amenity);
      //await _context.SaveChangesAsync();

      await this.amenities.Add(amenities);

            return CreatedAtAction("GetAmenity", new { id = amenities.Id }, amenities);
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
    //moved to databaseamenityrepository
    //private bool AmenityExists(int id)
    // {
    //     return _context.Amenities.Any(e => e.Id == id);
    // }


    //*********************************************************************
    //POST:  api/Amenities/5/Rooms/17
    [HttpPost]
    [Route("{id}/Rooms/{roomId}")]
    public async Task<IActionResult> AddAmenityToRoom ( int id, int roomId )
    {
      await this.amenities.AddRoom(id, roomId);
      return NoContent();
    }

    //DELETE:  api/Amenities/5/Rooms/17
    [HttpDelete]
    [Route("{id}/Rooms/{roomId}")]
    public async Task<IActionResult> RemoveFromRoom(int id, int roomId)
    {
      await amenities.RemoveAmenity(id, roomId);  //need to finish in the DatabaseAmenityRepository
      return NoContent();
    }
  }
}
