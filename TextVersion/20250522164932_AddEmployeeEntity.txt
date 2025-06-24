using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agri_EnergyConnect.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "880243aa-9d2a-4ec5-b50b-11c9805b76e5",
                column: "ConcurrencyStamp",
                value: "69ca4814-6ff2-43f7-88c5-673ab11223cc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a12b34cd-56ef-78gh-90ij-klmnopqrstuv",
                column: "ConcurrencyStamp",
                value: "7264ae7f-a1aa-4d97-a12a-5488920bbcfe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "880243aa-9d2a-4ec5-b50b-11c9805b76e5",
                column: "ConcurrencyStamp",
                value: "b6c72a36-6b22-47bb-9896-5198cc4d33d5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a12b34cd-56ef-78gh-90ij-klmnopqrstuv",
                column: "ConcurrencyStamp",
                value: "26e3bfc5-8dc3-4dd4-9c44-74df9f200918");
        }
    }
}
