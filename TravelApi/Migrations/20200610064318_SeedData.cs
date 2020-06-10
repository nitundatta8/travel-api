using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "PlaceId", "City", "Country", "Rating" },
                values: new object[,]
                {
                    { 1, "Tokyo", "Japan", 2.0 },
                    { 2, "Seattle", "US", 4.0 },
                    { 3, "London", "England", 3.0 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "PlaceId", "Rating", "ReviewText", "UserId" },
                values: new object[,]
                {
                    { 1, null, 2.0, "Great!", null },
                    { 2, null, 1.0, "I hated this place!", null },
                    { 3, null, 4.0, "Highly recommend!!", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Token", "Username" },
                values: new object[,]
                {
                    { 1, "Nitun", "Datta", "test", null, "test" },
                    { 2, "Purba", "Devi", "test1", null, "test1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
