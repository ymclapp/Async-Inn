// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using asyncInnApp.Data;

namespace asyncInnApp.Migrations
{
    [DbContext(typeof(HotelsDBContext))]
    [Migration("20211027011522_HadToFixSeedAAAGGGGAAAIIINNN")]
    partial class HadToFixSeedAAAGGGGAAAIIINNN
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("asyncInnApp.Models.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jacuzzi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kitchen"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pool Side Entrance"
                        });
                });

            modelBuilder.Entity("asyncInnApp.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Transylvania",
                            Country = "USA",
                            Name = "Hotel Transylvania",
                            Phone = "111-111-1111",
                            State = "PA",
                            StreetAddress = "111 Main St"
                        },
                        new
                        {
                            Id = 2,
                            City = "Estes Park",
                            Country = "USA",
                            Name = "Hotel Stanley",
                            Phone = "111-111-1111",
                            State = "CO",
                            StreetAddress = "111 Main St"
                        },
                        new
                        {
                            Id = 3,
                            City = "Beverly Hills",
                            Country = "USA",
                            Name = "Hotel Beverly Wilshire",
                            Phone = "111-111-1111",
                            State = "CA",
                            StreetAddress = "111 Main St"
                        });
                });

            modelBuilder.Entity("asyncInnApp.Models.HotelRoom", b =>
                {
                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("RoomNumber", "HotelId");

                    b.HasIndex("HotelId")
                        .IsUnique();

                    b.HasIndex("RoomId");

                    b.ToTable("HotelRooms");

                    b.HasData(
                        new
                        {
                            RoomNumber = 299,
                            HotelId = 1,
                            PetFriendly = true,
                            Rate = 300m,
                            RoomId = 3
                        },
                        new
                        {
                            RoomNumber = 102,
                            HotelId = 1,
                            PetFriendly = false,
                            Rate = 100m,
                            RoomId = 1
                        },
                        new
                        {
                            RoomNumber = 302,
                            HotelId = 1,
                            PetFriendly = true,
                            Rate = 500m,
                            RoomId = 3
                        },
                        new
                        {
                            RoomNumber = 201,
                            HotelId = 1,
                            PetFriendly = false,
                            Rate = 250m,
                            RoomId = 2
                        },
                        new
                        {
                            RoomNumber = 251,
                            HotelId = 1,
                            PetFriendly = false,
                            Rate = 250m,
                            RoomId = 2
                        });
                });

            modelBuilder.Entity("asyncInnApp.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Layout")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Layout = "Standard Room",
                            Name = "Seahawks Snooze",
                            RoomNumber = 0
                        },
                        new
                        {
                            Id = 2,
                            Layout = "Queen Suite",
                            Name = "Restful Rainier",
                            RoomNumber = 0
                        },
                        new
                        {
                            Id = 3,
                            Layout = "Ocean View",
                            Name = "Viscious View",
                            RoomNumber = 0
                        });
                });

            modelBuilder.Entity("asyncInnApp.Models.RoomAmenity", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("RoomAmenities");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            AmenityId = 1
                        });
                });

            modelBuilder.Entity("asyncInnApp.Models.HotelRoom", b =>
                {
                    b.HasOne("asyncInnApp.Models.Hotel", "Hotel")
                        .WithOne("HotelRooms")
                        .HasForeignKey("asyncInnApp.Models.HotelRoom", "HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("asyncInnApp.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("asyncInnApp.Models.RoomAmenity", b =>
                {
                    b.HasOne("asyncInnApp.Models.Amenity", "Amenity")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("asyncInnApp.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("asyncInnApp.Models.Amenity", b =>
                {
                    b.Navigation("RoomAmenities");
                });

            modelBuilder.Entity("asyncInnApp.Models.Hotel", b =>
                {
                    b.Navigation("HotelRooms");
                });

            modelBuilder.Entity("asyncInnApp.Models.Room", b =>
                {
                    b.Navigation("RoomAmenities");
                });
#pragma warning restore 612, 618
        }
    }
}
