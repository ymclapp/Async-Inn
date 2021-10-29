using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Models.DTO
{
  public class CreateHotelRoomData
  {
    public int HotelId { get; set; }

    [Required]
    public int RoomNumber { get; set; }

    [Column(TypeName = "money")]//default is decimal(18, 2)
    public decimal Rate { get; set; }
    public bool PetFriendly { get; set; }
    public int RoomId { get; set; }
    public RoomDTO Room { get; set; }

  }
}
