using Microsoft.EntityFrameworkCore.Migrations;

namespace asyncInnApp.Migrations
{
    public partial class AddedMoreHotelRoomSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 0 },
                column: "RoomId",
                value: 1);

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelId", "RoomNumber", "Id", "PetFriendly", "Rate", "RoomId" },
                values: new object[,]
                {
                    { 1, 102, 2, false, 100m, 2 },
                    { 1, 302, 3, true, 500m, 4 },
                    { 1, 201, 4, false, 250m, 3 }
                });
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
                keyValues: new object[] { 1, 302 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 0 },
                column: "RoomId",
                value: 4);
        }
    }
}
