using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAuthenticationServices.Infrastructure.Migrations
{
    public partial class ChangesInAuthenticationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAuthentications_Users_UserId1",
                table: "UserAuthentications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAuthentications",
                table: "UserAuthentications");

            migrationBuilder.DropIndex(
                name: "IX_UserAuthentications_UserId1",
                table: "UserAuthentications");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "UserAuthentications",
                newName: "AuthenticationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAuthentications",
                table: "UserAuthentications",
                column: "AuthenticationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthentications_UserId",
                table: "UserAuthentications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAuthentications_Users_UserId",
                table: "UserAuthentications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAuthentications_Users_UserId",
                table: "UserAuthentications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAuthentications",
                table: "UserAuthentications");

            migrationBuilder.DropIndex(
                name: "IX_UserAuthentications_UserId",
                table: "UserAuthentications");

            migrationBuilder.RenameColumn(
                name: "AuthenticationId",
                table: "UserAuthentications",
                newName: "UserId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAuthentications",
                table: "UserAuthentications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthentications_UserId1",
                table: "UserAuthentications",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAuthentications_Users_UserId1",
                table: "UserAuthentications",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
