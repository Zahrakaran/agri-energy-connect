using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agri_EnergyConnect.Migrations
{
    /// <inheritdoc />
    public partial class AddContactNumberToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Employees");
        }
    }
}
