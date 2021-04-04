using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagementSystem.Migrations
{
    public partial class Addresse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UserProfileDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "UserProfileDetails");
        }
    }
}
