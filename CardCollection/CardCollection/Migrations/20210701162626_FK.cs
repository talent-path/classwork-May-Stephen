using Microsoft.EntityFrameworkCore.Migrations;

namespace CardCollection.Migrations
{
    public partial class FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "TradeId",
                table: "Requests",
                newName: "tradeId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_TradeId",
                table: "Requests",
                newName: "IX_Requests_tradeId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Offers",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "TradeId",
                table: "Offers",
                newName: "tradeId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_UserId",
                table: "Offers",
                newName: "IX_Offers_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_TradeId",
                table: "Offers",
                newName: "IX_Offers_tradeId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AvailableTrades",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_AvailableTrades_UserId",
                table: "AvailableTrades",
                newName: "IX_AvailableTrades_userId");

            migrationBuilder.AlterColumn<int>(
                name: "tradeId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "tradeId",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "AvailableTrades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableTrades_Users_userId",
                table: "AvailableTrades",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AvailableTrades_tradeId",
                table: "Offers",
                column: "tradeId",
                principalTable: "AvailableTrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_userId",
                table: "Offers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AvailableTrades_tradeId",
                table: "Requests",
                column: "tradeId",
                principalTable: "AvailableTrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableTrades_Users_userId",
                table: "AvailableTrades");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AvailableTrades_tradeId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_userId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AvailableTrades_tradeId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "tradeId",
                table: "Requests",
                newName: "TradeId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_tradeId",
                table: "Requests",
                newName: "IX_Requests_TradeId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Offers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "tradeId",
                table: "Offers",
                newName: "TradeId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_userId",
                table: "Offers",
                newName: "IX_Offers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_tradeId",
                table: "Offers",
                newName: "IX_Offers_TradeId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "AvailableTrades",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AvailableTrades_userId",
                table: "AvailableTrades",
                newName: "IX_AvailableTrades_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "TradeId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TradeId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AvailableTrades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AvailableTrades_TradeId",
                table: "Requests",
                column: "TradeId",
                principalTable: "AvailableTrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
