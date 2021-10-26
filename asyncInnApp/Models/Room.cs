using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace asyncInnApp.Models
{
  public class Room
  {
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Layout { get; set; }
    public int RoomNumber { get; set; }

    //Reverse Navigation Properties - allows us to get to from amenity to the corresponding RoomAmenity

    public List<RoomAmenity> RoomAmenities { get; set; }

  }
}
