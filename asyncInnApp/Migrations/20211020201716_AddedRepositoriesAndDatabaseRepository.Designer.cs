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
    [Migration("20211020201716_AddedRepositoriesAndDatabaseRepository")]
    partial class AddedRepositoriesAndDatabaseRepository
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

            modelBuilder.Entity("asyncInnApp.Models.Hotels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
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
#pragma warning restore 612, 618
        }
    }
}
