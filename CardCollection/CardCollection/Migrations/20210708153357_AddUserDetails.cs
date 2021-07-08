using Microsoft.EntityFrameworkCore.Migrations;

namespace CardCollection.Migrations
{
    public partial class AddUserDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserDetailsId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserDetailsId",
                table: "Users",
                column: "UserDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserModel_UserDetailsId",
                table: "Users",
                column: "UserDetailsId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserModel_UserDetailsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserDetailsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserDetailsId",
                table: "Users");
        }
    }
}
