using Microsoft.EntityFrameworkCore.Migrations;

namespace CardCollection.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserModel_UserDetailsId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CardUserModel");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserDetailsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserDetailsId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "CardUser",
                columns: table => new
                {
                    OwnedCardsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OwnersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardUser", x => new { x.OwnedCardsId, x.OwnersId });
                    table.ForeignKey(
                        name: "FK_CardUser_Cards_OwnedCardsId",
                        column: x => x.OwnedCardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardUser_Users_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardUser_OwnersId",
                table: "CardUser",
                column: "OwnersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardUser");

            migrationBuilder.AddColumn<int>(
                name: "UserDetailsId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardUserModel",
                columns: table => new
                {
                    OwnersId = table.Column<int>(type: "int", nullable: false),
                    PersonalCollectionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardUserModel", x => new { x.OwnersId, x.PersonalCollectionId });
                    table.ForeignKey(
                        name: "FK_CardUserModel_Cards_PersonalCollectionId",
                        column: x => x.PersonalCollectionId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardUserModel_UserModel_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserDetailsId",
                table: "Users",
                column: "UserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CardUserModel_PersonalCollectionId",
                table: "CardUserModel",
                column: "PersonalCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserModel_UserDetailsId",
                table: "Users",
                column: "UserDetailsId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
