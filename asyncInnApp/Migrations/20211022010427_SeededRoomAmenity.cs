using Microsoft.EntityFrameworkCore.Migrations;

namespace asyncInnApp.Migrations
{
    public partial class SeededRoomAmenity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "AmenityId", "RoomId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenityId", "RoomId" },
                keyValues: new object[] { 1, 1 });
        }
    }
}
