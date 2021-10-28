using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;//for the column datetime
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Models.Identity
{
  public class ApplicationUser : IdentityUser
  {
    [Column(TypeName = "DATE")]  //store in sql as a DATE, not a DATETIME
    public DateTime DateOfBirth { get; set; }
    //public UserName
  }
}
