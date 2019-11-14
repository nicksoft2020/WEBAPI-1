using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDb.Migrations
{
    public partial class IdentityEmailFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UsersInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UsersInfo");
        }
    }
}
