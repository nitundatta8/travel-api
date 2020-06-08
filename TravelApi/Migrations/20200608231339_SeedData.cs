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
                values: new object[] { 1, "Tokyo", "Japan", 2.0 });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "PlaceId", "City", "Country", "Rating" },
                values: new object[] { 2, "Seattle", "US", 4.0 });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "PlaceId", "City", "Country", "Rating" },
                values: new object[] { 3, "London", "England", 3.0 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "PlaceId", "Rating", "ReviewText" },
                values: new object[] { 1, 1, 2.0, "Great!" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "PlaceId", "Rating", "ReviewText" },
                values: new object[] { 2, 2, 1.0, "I hated this place!" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "PlaceId", "Rating", "ReviewText" },
                values: new object[] { 3, 3, 4.0, "Highly recommend!!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
