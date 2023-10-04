using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareSolution.Migrations
{
    /// <inheritdoc />
    public partial class TopUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Orders_Orders2OrderID",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_Orders2OrderID",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Orders2OrderID",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Order2OrderID",
                table: "ShoppingCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "ShoppingCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_OrderID",
                table: "ShoppingCartItems",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Orders_OrderID",
                table: "ShoppingCartItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Orders_OrderID",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_OrderID",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "Order2OrderID",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "ShoppingCartItems");

            migrationBuilder.AddColumn<int>(
                name: "Orders2OrderID",
                table: "ShoppingCartItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_Orders2OrderID",
                table: "ShoppingCartItems",
                column: "Orders2OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserID",
                table: "Orders",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Orders_Orders2OrderID",
                table: "ShoppingCartItems",
                column: "Orders2OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID");
        }
    }
}
