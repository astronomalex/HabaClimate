using Microsoft.EntityFrameworkCore.Migrations;

namespace HabaClimate.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Good_AirConditionerId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "AirConditionerId",
                table: "CartItems",
                newName: "GoodId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_AirConditionerId",
                table: "CartItems",
                newName: "IX_CartItems_GoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Good_GoodId",
                table: "CartItems",
                column: "GoodId",
                principalTable: "Good",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Good_GoodId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "GoodId",
                table: "CartItems",
                newName: "AirConditionerId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_GoodId",
                table: "CartItems",
                newName: "IX_CartItems_AirConditionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Good_AirConditionerId",
                table: "CartItems",
                column: "AirConditionerId",
                principalTable: "Good",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
