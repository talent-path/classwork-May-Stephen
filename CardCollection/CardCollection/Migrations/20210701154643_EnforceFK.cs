using Microsoft.EntityFrameworkCore.Migrations;

namespace CardCollection.Migrations
{
    public partial class EnforceFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Requests_TradeId",
                table: "Requests",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_TradeId",
                table: "Offers",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UserId",
                table: "Offers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTrades_UserId",
                table: "AvailableTrades",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableTrades_Users_UserId",
                table: "AvailableTrades",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AvailableTrades_TradeId",
                table: "Offers",
                column: "TradeId",
                principalTable: "AvailableTrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_UserId",
                table: "Offers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AvailableTrades_TradeId",
                table: "Requests",
                column: "TradeId",
                principalTable: "AvailableTrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableTrades_Users_UserId",
                table: "AvailableTrades");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AvailableTrades_TradeId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_UserId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AvailableTrades_TradeId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_TradeId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Offers_TradeId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_UserId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_AvailableTrades_UserId",
                table: "AvailableTrades");
        }
    }
}
