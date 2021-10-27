using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Models
{
  public class HotelRoom
  {
    //public int Id { get; set; }
    //public int RoomNumber { get; set; }
    public int HotelId { get; set; }
    public int RoomId { get; set; }

    [Required]
    public decimal Rate { get; set; }
    public bool PetFriendly { get; set; }




    //Add Navigation property that will create a foreign key
    //Linked to RoomId/AmenityId by naming convention PropId

    [Required]
    public int RoomNumber { get; set; }
    public Hotel Hotel { get; set; }
    public Room Room { get; set; }
  }

  //public class RoomNumber
  //{
  //}
}
