using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrepaidCard.Data.Migrations
{
    public partial class RelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Purchase");

            migrationBuilder.AddColumn<int>(
                name: "CardEntityCardId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseCenterEntityPurchaseCenterId",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customer",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CardEntityCardId",
                table: "Purchase",
                column: "CardEntityCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PurchaseCenterEntityPurchaseCenterId",
                table: "Purchase",
                column: "PurchaseCenterEntityPurchaseCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_CustomerId",
                table: "Card",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Customer_CustomerId",
                table: "Card",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Card_CardEntityCardId",
                table: "Purchase",
                column: "CardEntityCardId",
                principalTable: "Card",
                principalColumn: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_PurchaseCenter_PurchaseCenterEntityPurchaseCenterId",
                table: "Purchase",
                column: "PurchaseCenterEntityPurchaseCenterId",
                principalTable: "PurchaseCenter",
                principalColumn: "PurchaseCenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Customer_CustomerId",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Card_CardEntityCardId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_PurchaseCenter_PurchaseCenterEntityPurchaseCenterId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_CardEntityCardId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_PurchaseCenterEntityPurchaseCenterId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Card_CustomerId",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "CardEntityCardId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "PurchaseCenterEntityPurchaseCenterId",
                table: "Purchase");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
