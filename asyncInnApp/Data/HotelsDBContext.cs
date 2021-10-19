using asyncInnApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Data
{
  public class HotelsDBContext : DbContext
  {
    public HotelsDBContext(DbContextOptions options) : base(options) { }

    //there should be a hotels table with hotel records in it
    public DbSet<Hotels> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Hotels>()
        .HasData(
        new Hotels {
          Id = 1,
          Name = "Hotel Transylvania",
          StreetAddress = "111 Main St",
          City = "Transylvania",
          State = "PA",
          Country = "USA",
          Phone = "111-111-1111"
        },
        new Hotels {
          Id = 2,
          Name = "Hotel Stanley"
          StreetAddress = "111 Main St",
          City = "Estes Park",
          State = "CO",
          Country = "USA",
          Phone = "111-111-1111"
        },
        new Hotels {
          Id = 3,
          Name = "Hotel Beverly Wilshire"}
        );
      modelBuilder.Entity<Room>()
        .HasData(
        new Room { Id = 1},
        new Room { Id = 2},
        new Room { Id = 3}
        );
      modelBuilder.Entity<Amenity>()
        .HasData(
        new Amenity { Id = 1},
        new Amenity { Id = 2},
        new Amenity { Id = 3}
        );
    }
  }
}
