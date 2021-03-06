using asyncInnApp.Models;
using asyncInnApp.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncInnApp.Data
{
  public class HotelsDBContext : IdentityDbContext<ApplicationUser>
  {
    public HotelsDBContext(DbContextOptions options) : base(options) { }

    //there should be a hotels table with hotel records in it
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
    public DbSet<RoomAmenity> RoomAmenities { get; set; }
    public DbSet<HotelRoom> HotelRooms { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // This calls the base method, and Identity needs it
      base.OnModelCreating(modelBuilder);

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

      modelBuilder.Entity<HotelRoom>()
        .HasKey(h => new { h.RoomNumber, h.HotelId });//<<--creates composite key for table

      modelBuilder.Entity<HotelRoom>()
        .HasData(
            new HotelRoom
            {
              RoomNumber = 299,
              HotelId = 1,
              RoomId = 3,
              Rate = 300,
              PetFriendly = true
            },
            new HotelRoom
            {
              RoomNumber = 102,
              HotelId = 1,
              RoomId = 1,
              Rate = 100,
              PetFriendly = false
            },
            new HotelRoom
            {
              RoomNumber = 302,
              HotelId = 1,
              RoomId = 3,
              Rate = 500,
              PetFriendly = true
            },
            new HotelRoom
            {
              RoomNumber = 201,
              HotelId = 1,
              RoomId = 2,
              Rate = 250,
              PetFriendly = false
            },
            new HotelRoom
            {
              RoomNumber = 251,
              HotelId = 1,
              RoomId = 2,
              Rate = 250,
              PetFriendly = false
            }

     );
      SeedRole(modelBuilder, "Administrator");
      SeedRole(modelBuilder, "Editor");
      SeedRole(modelBuilder, "Admissions");
      SeedRole(modelBuilder, "District Manager");
      SeedRole(modelBuilder, "Property Manager");
      SeedRole(modelBuilder, "Agent");
      SeedRole(modelBuilder, "Anonymous");

    }

    private void SeedRole ( ModelBuilder modelBuilder, string roleName )
    {
      var role = new IdentityRole
      {
        Id = roleName,
        Name = roleName,
        NormalizedName = roleName.ToUpper(),
        ConcurrencyStamp = Guid.Empty.ToString(),
      };
      modelBuilder.Entity<IdentityRole>().HasData(role);
    }
  }
}
