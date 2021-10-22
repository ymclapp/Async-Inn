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
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
    public DbSet<RoomAmenity> RoomAmenities { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Hotel>()
        .HasData(
        new Hotel {
          Id = 1,
          Name = "Hotel Transylvania",
          StreetAddress = "111 Main St",
          City = "Transylvania",
          State = "PA",
          Country = "USA",
          Phone = "111-111-1111"
        },
        new Hotel {
          Id = 2,
          Name = "Hotel Stanley",
          StreetAddress = "111 Main St",
          City = "Estes Park",
          State = "CO",
          Country = "USA",
          Phone = "111-111-1111"
        },
        new Hotel {
          Id = 3,
          Name = "Hotel Beverly Wilshire",
          StreetAddress = "111 Main St",
          City = "Beverly Hills",
          State = "CA",
          Country = "USA",
          Phone = "111-111-1111"
        }
        );
      modelBuilder.Entity<Room>()
        .HasData(
        new Room {
          Id = 1,
          Name = "Seahawks Snooze",
          Layout = "Standard Room"
        },
        new Room {
          Id = 2,
          Name = "Restful Rainier",
          Layout = "Queen Suite"
        },
        new Room {
          Id = 3,
          Name = "Viscious View",
          Layout = "Ocean View"
        }
        );
      modelBuilder.Entity<Amenity>()
        .HasData(
        new Amenity {
          Id = 1,
          Name = "Jacuzzi"
        },
        new Amenity {
          Id = 2,
          Name = "Kitchen"
        },
        new Amenity {
          Id = 3,
          Name = "Pool Side Entrance"
        }
        );

      modelBuilder.Entity<RoomAmenity>()
        .HasKey(r => new { r.RoomId, r.AmenityId });  //<<--anonymous type - new {...} - creates composite key for table

      modelBuilder.Entity<RoomAmenity>()
        .HasData(
          new RoomAmenity { RoomId = 1, AmenityId = 1 }
        );
    }
  }
}
