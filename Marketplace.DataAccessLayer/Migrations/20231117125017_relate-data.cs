using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class relatedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
