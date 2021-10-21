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
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string StreetAddress { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string State { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string Phone { get; set; }

    //internal static Task Add ( Hotel hotels )
    //{
   //   throw new NotImplementedException();
    //}
  }
}
