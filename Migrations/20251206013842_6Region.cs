using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class _6Region : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 1,
                column: "regionName",
                value: "Africa");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 2,
                column: "regionName",
                value: "Asia");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 3,
                column: "regionName",
                value: "Europe");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 4,
                column: "regionName",
                value: "North America");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 5,
                column: "regionName",
                value: "South America");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 6,
                column: "regionName",
                value: "Oceania");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 7,
                column: "regionName",
                value: "Antarctica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 1,
                column: "regionName",
                value: "Vietnam");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 2,
                column: "regionName",
                value: "United States");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 3,
                column: "regionName",
                value: "Japan");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 4,
                column: "regionName",
                value: "South Korea");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 5,
                column: "regionName",
                value: "China");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 6,
                column: "regionName",
                value: "United Kingdom");

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: 7,
                column: "regionName",
                value: "France");

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "regionName" },
                values: new object[,]
                {
                    { 8, "Germany" },
                    { 9, "Canada" },
                    { 10, "Australia" },
                    { 11, "Brazil" },
                    { 12, "India" },
                    { 13, "Thailand" },
                    { 14, "Singapore" },
                    { 15, "Netherlands" },
                    { 16, "Switzerland" },
                    { 17, "Sweden" },
                    { 18, "Italy" },
                    { 19, "Spain" },
                    { 20, "Russia" }
                });
        }
    }
}
