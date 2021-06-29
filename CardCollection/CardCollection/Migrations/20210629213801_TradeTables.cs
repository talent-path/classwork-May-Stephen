using Microsoft.EntityFrameworkCore.Migrations;

namespace CardCollection.Migrations
{
    public partial class TradeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AvailableTrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardTrade",
                columns: table => new
                {
                    CardsOfferedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TradeOffersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTrade", x => new { x.CardsOfferedId, x.TradeOffersId });
                    table.ForeignKey(
                        name: "FK_CardTrade_AvailableTrades_TradeOffersId",
                        column: x => x.TradeOffersId,
                        principalTable: "AvailableTrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardTrade_Cards_CardsOfferedId",
                        column: x => x.CardsOfferedId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_OfferId",
                table: "Cards",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_RequestId",
                table: "Cards",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_CardTrade_TradeOffersId",
                table: "CardTrade",
                column: "TradeOffersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Offers_OfferId",
                table: "Cards",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Requests_RequestId",
                table: "Cards",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Offers_OfferId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Requests_RequestId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "CardTrade");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "AvailableTrades");

            migrationBuilder.DropIndex(
                name: "IX_Cards_OfferId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_RequestId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Cards");
        }
    }
}
