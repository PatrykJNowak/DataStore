using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAuthenticationServices.Infrastructure.Migrations
{
    public partial class AddUserContentFileDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserContentFiles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserContentFiles");
        }
    }
}
