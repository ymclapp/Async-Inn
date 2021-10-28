using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Models.Identity
{
  public class RegisterData
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }
    public bool AcceptedTerms { get; set; }

    //we could add more, like FirstName or LastName, but would have to add to the standardized framwork for Identiity
  }
}
