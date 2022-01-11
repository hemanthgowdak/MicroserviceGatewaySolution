using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerApi.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDelivered_Customers_CustomerId",
                table: "ProductDelivered");

            migrationBuilder.DropIndex(
                name: "IX_ProductDelivered_CustomerId",
                table: "ProductDelivered");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductDelivered_CustomerId",
                table: "ProductDelivered",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDelivered_Customers_CustomerId",
                table: "ProductDelivered",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
