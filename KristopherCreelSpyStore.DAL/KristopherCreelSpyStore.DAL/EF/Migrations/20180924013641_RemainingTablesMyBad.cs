using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KristopherCreelSpyStore.DAL.EF.Migrations
{
    public partial class RemainingTablesMyBad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDeatails_Orders_OrderId",
                schema: "Store",
                table: "OrderDeatails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDeatails_Products_ProductId",
                schema: "Store",
                table: "OrderDeatails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDeatails",
                schema: "Store",
                table: "OrderDeatails");

            migrationBuilder.RenameTable(
                name: "OrderDeatails",
                schema: "Store",
                newName: "OrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDeatails_ProductId",
                schema: "Store",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDeatails_OrderId",
                schema: "Store",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                schema: "Store",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                schema: "Store",
                table: "OrderDetails",
                column: "OrderId",
                principalSchema: "Store",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                schema: "Store",
                table: "OrderDetails",
                column: "ProductId",
                principalSchema: "Store",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                schema: "Store",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                schema: "Store",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                schema: "Store",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                schema: "Store",
                newName: "OrderDeatails");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductId",
                schema: "Store",
                table: "OrderDeatails",
                newName: "IX_OrderDeatails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                schema: "Store",
                table: "OrderDeatails",
                newName: "IX_OrderDeatails_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDeatails",
                schema: "Store",
                table: "OrderDeatails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDeatails_Orders_OrderId",
                schema: "Store",
                table: "OrderDeatails",
                column: "OrderId",
                principalSchema: "Store",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDeatails_Products_ProductId",
                schema: "Store",
                table: "OrderDeatails",
                column: "ProductId",
                principalSchema: "Store",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
