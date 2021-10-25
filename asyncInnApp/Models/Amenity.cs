using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace asyncInnApp.Models
{
  public class Amenity
  {
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    //Reverse Navigation Properties - allows us to get to from amenity to the corresponding RoomAmenity
    public List<RoomAmenity> RoomAmenities { get; set; }
  }
}
