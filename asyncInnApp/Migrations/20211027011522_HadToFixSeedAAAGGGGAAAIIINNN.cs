using Microsoft.EntityFrameworkCore.Migrations;

namespace asyncInnApp.Migrations
{
    public partial class HadToFixSeedAAAGGGGAAAIIINNN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelId", "RoomNumber", "PetFriendly", "Rate", "RoomId" },
                values: new object[] { 1, 251, false, 250m, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 102 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 201 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 251 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 299 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 302 });
        }
    }
}
