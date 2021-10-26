using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Models
{
  public class HotelRoom
  {
    public int Id { get; set; }
    public int RoomNumber { get; set; }
    public int HotelId { get; set; }
    public int RoomId { get; set; }
    public decimal Rate { get; set; }
    public bool PetFriendly { get; set; }




    //Add Navigation property that will create a foreign key
    //Linked to RoomId/AmenityId by naming convention PropId
    //public RoomNumber RoomNumber { get; set; }
    public Hotel Hotel { get; set; }
  }

  //public async class RoomNumber
  //{
  //}
}
