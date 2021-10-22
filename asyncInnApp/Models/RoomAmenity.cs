using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Models
{
  public class RoomAmenity
  {
    public int RoomId { get; set; }
    public int AmenityId { get; set; }

    //Add Navigation property that will create a foreign key
    //Linked to RoomId/AmenityId by naming convention PropId
    public Room RARoom { get; set; }
    public Amenity RAAmenity { get; set; }
  }
}
