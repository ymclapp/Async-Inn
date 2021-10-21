using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Models
{
  public class Hotel
  {
    public int Id { get; set; } [Required]
    public string Name { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }

    internal static Task Add ( Hotel hotels )
    {
      throw new NotImplementedException();
    }
  }
}
