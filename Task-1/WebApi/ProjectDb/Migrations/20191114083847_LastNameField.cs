using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDb.Migrations
{
    public partial class LastNameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UsersInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UsersInfo");
        }
    }
}
