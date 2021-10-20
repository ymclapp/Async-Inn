using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace asyncInnApp.Models
{
  public class Room
  {
    public int Id { get; set; } [Required]
    public string Name { get; set; }
    public string Layout { get; set; }
  }
}
