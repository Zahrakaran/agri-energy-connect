using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Agri_EnergyConnect.Migrations
{
    /// <inheritdoc />
    public partial class SeedJohnAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "880243aa-9d2a-4ec5-b50b-11c9805b76e5", 0, "b6c72a36-6b22-47bb-9896-5198cc4d33d5", "nomsa@agri.com", true, "Nomsa Dlamini", false, null, "NOMSA@AGRI.COM", "NOMSA@AGRI.COM", "AQAAAAEAACcQAAAAEFzmKe2T3ru73AUrrqiju4UyYSwFEklATmoeXCcV7x61Qea2CoPoKGO4cuu8eTWrgQ==", "0712345678", true, "5db952e8-61db-4b7d-bb2e-0d0abb1f43c7", false, "nomsa@agri.com" },
                    { "a12b34cd-56ef-78gh-90ij-klmnopqrstuv", 0, "26e3bfc5-8dc3-4dd4-9c44-74df9f200918", "john.smith@agri.com", true, "John Smith", false, null, "JOHN.SMITH@AGRI.COM", "JOHN.SMITH@AGRI.COM", "AQAAAAEAACcQAAAAEFO7SIaVHatyypRann9Kki1DDf8znG6s/CxyaIxOPPtrjv2/b7NfDCFlnSB62u3nIw==", "0723456789", true, "c982bc2f-aa5e-4fc2-8b3a-513aa587b54f", false, "john.smith@agri.com" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ContactNumber", "Email", "FullName", "IdentityUserId", "Position" },
                values: new object[] { 1, "0723456789", "john.smith@agri.com", "John Smith", "a12b34cd-56ef-78gh-90ij-klmnopqrstuv", "Product Manager" });

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "Id", "ContactNumber", "Email", "FullName", "IdentityUserId", "Location" },
                values: new object[] { 1, "0712345678", "nomsa@agri.com", "Nomsa Dlamini", "880243aa-9d2a-4ec5-b50b-11c9805b76e5", "Limpopo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "880243aa-9d2a-4ec5-b50b-11c9805b76e5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a12b34cd-56ef-78gh-90ij-klmnopqrstuv");
        }
    }
}
