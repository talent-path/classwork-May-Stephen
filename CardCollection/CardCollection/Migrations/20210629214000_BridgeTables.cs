using Microsoft.EntityFrameworkCore.Migrations;

namespace CardCollection.Migrations
{
    public partial class BridgeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Offers_OfferId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Requests_RequestId",
                table: "Cards");

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

            migrationBuilder.CreateTable(
                name: "CardOffer",
                columns: table => new
                {
                    OfferedCardsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OffersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardOffer", x => new { x.OfferedCardsId, x.OffersId });
                    table.ForeignKey(
                        name: "FK_CardOffer_Cards_OfferedCardsId",
                        column: x => x.OfferedCardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardOffer_Offers_OffersId",
                        column: x => x.OffersId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardRequest",
                columns: table => new
                {
                    RequestedCardsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardRequest", x => new { x.RequestedCardsId, x.RequestsId });
                    table.ForeignKey(
                        name: "FK_CardRequest_Cards_RequestedCardsId",
                        column: x => x.RequestedCardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardRequest_Requests_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardOffer_OffersId",
                table: "CardOffer",
                column: "OffersId");

            migrationBuilder.CreateIndex(
                name: "IX_CardRequest_RequestsId",
                table: "CardRequest",
                column: "RequestsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardOffer");

            migrationBuilder.DropTable(
                name: "CardRequest");

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

            migrationBuilder.CreateIndex(
                name: "IX_Cards_OfferId",
                table: "Cards",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_RequestId",
                table: "Cards",
                column: "RequestId");

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
    }
}
