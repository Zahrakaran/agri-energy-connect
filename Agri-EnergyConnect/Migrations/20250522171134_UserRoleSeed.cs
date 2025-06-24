using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Agri_EnergyConnect.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e05aeea-4c6a-485f-aac3-7f21c20578ab", null, "Farmer", "FARMER" },
                    { "5a2d7d82-4261-4e1c-8bdb-4d9185f93a05", null, "Employee", "EMPLOYEE" },
                    { "5d5863cd-0108-4b11-ac8f-43e1bacb689e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "880243aa-9d2a-4ec5-b50b-11c9805b76e5",
                column: "ConcurrencyStamp",
                value: "8d523d6f-6e97-4cf0-b947-65a5e82f3d5f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a12b34cd-56ef-78gh-90ij-klmnopqrstuv",
                column: "ConcurrencyStamp",
                value: "687ede70-75ff-42ce-86f6-7a835032d482");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4e05aeea-4c6a-485f-aac3-7f21c20578ab", "880243aa-9d2a-4ec5-b50b-11c9805b76e5" },
                    { "5a2d7d82-4261-4e1c-8bdb-4d9185f93a05", "a12b34cd-56ef-78gh-90ij-klmnopqrstuv" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d5863cd-0108-4b11-ac8f-43e1bacb689e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4e05aeea-4c6a-485f-aac3-7f21c20578ab", "880243aa-9d2a-4ec5-b50b-11c9805b76e5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5a2d7d82-4261-4e1c-8bdb-4d9185f93a05", "a12b34cd-56ef-78gh-90ij-klmnopqrstuv" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e05aeea-4c6a-485f-aac3-7f21c20578ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a2d7d82-4261-4e1c-8bdb-4d9185f93a05");

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
    }
}
