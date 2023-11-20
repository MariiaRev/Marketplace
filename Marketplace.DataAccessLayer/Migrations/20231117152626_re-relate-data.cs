using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class rerelatedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Auctions_AuctionId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_AuctionId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AuctionId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_ItemId",
                table: "Auctions",
                column: "ItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Items_ItemId",
                table: "Auctions",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Items_ItemId",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_ItemId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Auctions");

            migrationBuilder.AddColumn<int>(
                name: "AuctionId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_AuctionId",
                table: "Items",
                column: "AuctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Auctions_AuctionId",
                table: "Items",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id");
        }
    }
}
