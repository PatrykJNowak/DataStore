using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAuthenticationServices.Infrastructure.Migrations
{
    public partial class AddUserLevelProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserLevel",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLevel",
                table: "Users");
        }
    }
}
