﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using asyncInnApp.Data;

namespace asyncInnApp.Migrations
{
    [DbContext(typeof(HotelsDBContext))]
    [Migration("20211022011602_UpdatedRoomAmenityForeignKeys")]
    partial class UpdatedRoomAmenityForeignKeys
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

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Layout = "Standard Room",
                            Name = "Seahawks Snooze"
                        },
                        new
                        {
                            Id = 2,
                            Layout = "Queen Suite",
                            Name = "Restful Rainier"
                        },
                        new
                        {
                            Id = 3,
                            Layout = "Ocean View",
                            Name = "Viscious View"
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

            modelBuilder.Entity("asyncInnApp.Models.RoomAmenity", b =>
                {
                    b.HasOne("asyncInnApp.Models.Amenity", "FKAmenity")
                        .WithMany()
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("asyncInnApp.Models.Room", "FKRoom")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FKAmenity");

                    b.Navigation("FKRoom");
                });
#pragma warning restore 612, 618
        }
    }
}
